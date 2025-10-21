using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.ViewModels;

namespace Contracts.StorageContracts
{
	public interface IParticipantStorage
	{
		List<ParticipantViewModel> GetFullList();

		List<ParticipantViewModel> GetFilteredList(ParticipantSearchModel model);

		ParticipantViewModel? GetElement(ParticipantSearchModel model);

		ParticipantViewModel? Insert(ParticipantBindingModel model);

		ParticipantViewModel? Update(ParticipantBindingModel model);

		ParticipantViewModel? Delete(ParticipantBindingModel model);
	}
}
