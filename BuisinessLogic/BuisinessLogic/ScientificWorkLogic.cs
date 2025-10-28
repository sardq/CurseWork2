using Contracts.BindingModels;
using Contracts.BusinessLogicContracts;
using Contracts.SearchModels;
using Contracts.StorageContracts;
using Contracts.ViewModels;
using DataModels.Enums;
using Microsoft.Extensions.Logging;

namespace BuisinessLogic.BusinessLogic
{
	public class ScientificWorkLogic : IScientificWorkLogic 
	{
		private readonly ILogger _logger;

		private readonly IScientificWorkStorage _scientificWorkStorage;

		public ScientificWorkLogic(ILogger<ScientificWorkLogic> logger, IScientificWorkStorage scientificWorkStorage)
		{
			_logger = logger;
			_scientificWorkStorage = scientificWorkStorage;
		}

		public List<ScientificWorkViewModel>? ReadList(ScientificWorkSearchModel? model)
		{
			_logger.LogInformation("ReadList.Name:{Name} Id:{Id}",model?.Name, model?.Id);
			var list = model == null ? _scientificWorkStorage.GetFullList() : _scientificWorkStorage.GetFilteredList(model);
			if (list == null)
			{
				_logger.LogWarning("ReadList return null list");
				return null;
			}
			_logger.LogInformation("ReadList. Count:{Count}", list.Count);
			return list;
		}

		public ScientificWorkViewModel? ReadElement(ScientificWorkSearchModel model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			_logger.LogInformation("ReadElement.Name:{Name} Id:{Id}", model.Name, model.Id);
			var element = _scientificWorkStorage.GetElement(model);
			if (element == null)
			{
				_logger.LogWarning("ReadElement element not found");
				return null;
			}
			_logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
			return element;
		}

		public bool Create(ScientificWorkBindingModel model)
		{
			CheckModel(model);
			if (_scientificWorkStorage.Insert(model) == null)
			{
				_logger.LogWarning("Insert operation failed");
				return false;
			}
			return true;
		}

		public bool Update(ScientificWorkBindingModel model)
		{
			CheckModel(model);
			if (_scientificWorkStorage.Update(model) == null)
			{
				_logger.LogWarning("Update operation failed");
				return false;
			}
			return true;
		}

		public bool Delete(ScientificWorkBindingModel model)
		{
			CheckModel(model, false);
			_logger.LogInformation("Delete. Id:{Id}", model.Id);
			if (_scientificWorkStorage.Delete(model) == null)
			{
				_logger.LogWarning("Delete operation failed");
				return false;
			}
			return true;
		}

		private void CheckModel(ScientificWorkBindingModel model, bool withParams = true)
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
				throw new ArgumentNullException("Нет наименования научной работы", nameof(model.Name));
			}
			if (model.Year < 1900 || model.Year > 2025)
			{
				throw new ArgumentException("Неправильный год", nameof(model.Year));
			}
			if (model.Status == ScientificWorkStatus.Draft)
			{
				throw new ArgumentException("Нет статуса научной работы", nameof(model.Status));
			}
			if (model.Type == ScientificWorkType.None)
			{
				throw new ArgumentException("Нет типа научной работы", nameof(model.Type));
			}
			_logger.LogInformation("ScientificWork. Name:{Name}. Year:{Year}. Status:{Status}. Type:{Type}.", model.Name, model.Year, model.Status, model.Type);
			var element = _scientificWorkStorage.GetElement(new ScientificWorkSearchModel
			{
				Name = model.Name,

			});
			if (element != null && element.Id != model.Id)
			{
				throw new InvalidOperationException("Научная работа с такими данными уже есть");
			}
		}
	}
}
