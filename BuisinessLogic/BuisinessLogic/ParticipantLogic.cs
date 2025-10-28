using Contracts.BindingModels;
using Contracts.BusinessLogicContracts;
using Contracts.SearchModels;
using Contracts.StorageContracts;
using Contracts.ViewModels;
using DataModels.Enums;
using Microsoft.Extensions.Logging;

namespace BuisinessLogic.BusinessLogic
{
	public class ParticipantLogic : IParticipantLogic
	{
		private readonly ILogger _logger;

		private readonly IParticipantStorage _participantStorage;

		public ParticipantLogic(ILogger<ParticipantLogic> logger, IParticipantStorage participantStorage)
		{
			_logger = logger;
			_participantStorage = participantStorage;
		}

		public List<ParticipantViewModel>? ReadList(ParticipantSearchModel? model)
		{
			_logger.LogInformation("ReadList. Id:{Id}", model?.Id);
			var list = model == null ? _participantStorage.GetFullList() : _participantStorage.GetFilteredList(model);
			if (list == null)
			{
				_logger.LogWarning("ReadList return null list");
				return null;
			}
			_logger.LogInformation("ReadList. Count:{Count}", list.Count);
			return list;
		}

		public ParticipantViewModel? ReadElement(ParticipantSearchModel model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			_logger.LogInformation("ReadElement. Id:{Id}", model.Id);
			var element = _participantStorage.GetElement(model);
			if (element == null)
			{
				_logger.LogWarning("ReadElement element not found");
				return null;
			}
			_logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
			return element;
		}

		public bool Create(ParticipantBindingModel model)
		{
			CheckModel(model);
			if (_participantStorage.Insert(model) == null)
			{
				_logger.LogWarning("Insert operation failed");
				return false;
			}
			return true;
		}

		public bool Update(ParticipantBindingModel model)
		{
			CheckModel(model);
			if (_participantStorage.Update(model) == null)
			{
				_logger.LogWarning("Update operation failed");
				return false;
			}
			return true;
		}

		public bool Delete(ParticipantBindingModel model)
		{
			CheckModel(model, false);
			_logger.LogInformation("Delete. Id:{Id}", model.Id);
			if (_participantStorage.Delete(model) == null)
			{
				_logger.LogWarning("Delete operation failed");
				return false;
			}
			return true;
		}

		private void CheckModel(ParticipantBindingModel model, bool withParams = true)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			if (!withParams)
			{
				return;
			}
			if (model.Role == ParticipantRole.None)
			{
				throw new ArgumentException("Нет роли участника", nameof(model.Role));
			}
			_logger.LogInformation("Participant. Role:{Role}.", model.Role);
			var element = _participantStorage.GetElement(new ParticipantSearchModel
			{
				ScientificWorkId = model.ScientificWorkId,
				TeacherId = model.TeacherId,

			});
			if (element != null && element.Id != model.Id)
			{
				throw new InvalidOperationException("Учасстник с такими данными уже есть");
			}
		}
	}
}
