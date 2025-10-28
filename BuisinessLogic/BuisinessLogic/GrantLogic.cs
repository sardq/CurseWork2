using Contracts.SearchModels;
using Contracts.BusinessLogicContracts;
using Contracts.StorageContracts;
using Contracts.BindingModels;
using Contracts.ViewModels;
using Microsoft.Extensions.Logging;
using DataModels.Enums;

namespace BuisinessLogic.BusinessLogic
{
	public class GrantLogic : IGrantLogic
	{
		private readonly ILogger _logger;

		private readonly IGrantStorage _grantStorage;

		public GrantLogic(ILogger<GrantLogic> logger, IGrantStorage grantStorage)
		{
			_logger = logger;
			_grantStorage = grantStorage;
		}

		public List<GrantViewModel>? ReadList(GrantSearchModel? model)
		{
			_logger.LogInformation("ReadList. Name:{Name}. Id:{Id}", model?.Name, model?.Id);
			var list = model == null ? _grantStorage.GetFullList() : _grantStorage.GetFilteredList(model);
			if (list == null)
			{
				_logger.LogWarning("ReadList return null list");
				return null;
			}
			_logger.LogInformation("ReadList. Count:{Count}", list.Count);
			return list;
		}

		public GrantViewModel? ReadElement(GrantSearchModel model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			_logger.LogInformation("ReadElement. Name:{Name}. Id:{Id}", model.Name, model.Id);
			var element = _grantStorage.GetElement(model);
			if (element == null)
			{
				_logger.LogWarning("ReadElement element not found");
				return null;
			}
			_logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
			return element;
		}

		public bool Create(GrantBindingModel model)
		{
			CheckModel(model);
			if (_grantStorage.Insert(model) == null)
			{
				_logger.LogWarning("Insert operation failed");
				return false;
			}
			return true;
		}

		public bool Update(GrantBindingModel model)
		{
			CheckModel(model);
			if (_grantStorage.Update(model) == null)
			{
				_logger.LogWarning("Update operation failed");
				return false;
			}
			return true;
		}

		public bool Delete(GrantBindingModel model)
		{
			CheckModel(model, false);
			_logger.LogInformation("Delete. Id:{Id}", model.Id);
			if (_grantStorage.Delete(model) == null)
			{
				_logger.LogWarning("Delete operation failed");
				return false;
			}
			return true;
		}

		private void CheckModel(GrantBindingModel model, bool withParams = true)
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
				throw new ArgumentNullException("Нет наименования гранта", nameof(model.Name));
			}
			if (model.Year < 1900 || model.Year > 2025)
			{
				throw new ArgumentException("Неправильный год", nameof(model.Year));
			}
			if (model.Amount < 0)
			{
				throw new ArgumentException("Нет суммы", nameof(model.Amount));
			}
			if (model.Status == GrantStatus.Draft)
			{
				throw new ArgumentException("Нет статуса гранта", nameof(model.Status));
			}
			if (model.Type == GrantTypeEnum.None)
			{
				throw new ArgumentException("Нет типа гранта", nameof(model.Type));
			}
			_logger.LogInformation("Grant. Name:{Name}. Year:{Year}. Amount:{Amount}. Status:{Status}. Type:{Type}.", model.Name, model.Year, model.Amount, model.Status, model.Type);
			var element = _grantStorage.GetElement(new GrantSearchModel
			{
				Name = model.Name,

			});
			if (element != null && element.Id != model.Id)
			{
				throw new InvalidOperationException("Грант с такими данными уже есть");
			}
		}
	}
}
