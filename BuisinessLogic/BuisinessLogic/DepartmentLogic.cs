using Contracts.SearchModels;
using Contracts.BusinessLogicContracts;
using Contracts.StorageContracts;
using Contracts.BindingModels;
using Contracts.ViewModels;
using Microsoft.Extensions.Logging;

namespace BuisinessLogic.BusinessLogic
{
	public class DepartmentLogic : IDepartmentLogic
	{
		private readonly ILogger _logger;

		private readonly IDepartmentStorage _departmentStorage;

		public DepartmentLogic(ILogger<DepartmentLogic> logger, IDepartmentStorage departmentStorage)
		{
			_logger = logger;
			_departmentStorage = departmentStorage;
		}

		public List<DepartmentViewModel>? ReadList(DepartmentSearchModel? model)
		{
			_logger.LogInformation("ReadList. Name:{Name}. Id:{Id}", model?.Name, model?.Id);
			var list = model == null ? _departmentStorage.GetFullList() : _departmentStorage.GetFilteredList(model);
			if (list == null)
			{
				_logger.LogWarning("ReadList return null list");
				return null;
			}
			_logger.LogInformation("ReadList. Count:{Count}", list.Count);
			return list;
		}

		public DepartmentViewModel? ReadElement(DepartmentSearchModel model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			_logger.LogInformation("ReadElement. Name:{Name}. Id:{Id}", model.Name, model.Id);
			var element = _departmentStorage.GetElement(model);
			if (element == null)
			{
				_logger.LogWarning("ReadElement element not found");
				return null;
			}
			_logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
			return element;
		}

		public bool Create(DepartmentBindingModel model)
		{
			CheckModel(model);
			if (_departmentStorage.Insert(model) == null)
			{
				_logger.LogWarning("Insert operation failed");
				return false;
			}
			return true;
		}

		public bool Update(DepartmentBindingModel model)
		{
			CheckModel(model);
			if (_departmentStorage.Update(model) == null)
			{
				_logger.LogWarning("Update operation failed");
				return false;
			}
			return true;
		}

		public bool Delete(DepartmentBindingModel model)
		{
			CheckModel(model, false);
			_logger.LogInformation("Delete. Id:{Id}", model.Id);
			if (_departmentStorage.Delete(model) == null)
			{
				_logger.LogWarning("Delete operation failed");
				return false;
			}
			return true;
		}

		private void CheckModel(DepartmentBindingModel model, bool withParams = true)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			if (!withParams)
			{
				return;
			}
			if (string.IsNullOrEmpty(model.Name))
			{
				throw new ArgumentNullException("Нет наименования кафедры", nameof(model.Name));
			}
			if (string.IsNullOrEmpty(model.Address))
			{
				throw new ArgumentException("Нет адреса", nameof(model.Address));
			}
			_logger.LogInformation("Department. Name:{Name}. Address:{Address}.", model.Name, model.Address);
			var element = _departmentStorage.GetElement(new DepartmentSearchModel
			{
				Name = model.Name,

			});
			if (element != null && element.Id != model.Id)
			{
				throw new InvalidOperationException("Кафедра с такими данными уже есть");
			}
		}
	}
}
