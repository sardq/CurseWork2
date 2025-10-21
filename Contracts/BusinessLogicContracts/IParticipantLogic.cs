using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.ViewModels;

namespace Contracts.BusinessLogicContracts
{
	public interface IParticipantLogic
	{
		List<ParticipantViewModel>? ReadList(ParticipantSearchModel? model);

		ParticipantViewModel? ReadElement(ParticipantSearchModel model);

		bool Create(ParticipantBindingModel model);

		bool Update(ParticipantBindingModel model);

		bool Delete(ParticipantBindingModel model);
	}
}
