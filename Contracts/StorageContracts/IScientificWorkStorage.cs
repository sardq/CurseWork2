using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.ViewModels;

namespace Contracts.StorageContracts
{
	public interface IScientificWorkStorage
	{
		List<ScientificWorkViewModel> GetFullList();

		List<ScientificWorkViewModel> GetFilteredList(ScientificWorkSearchModel model);

		ScientificWorkViewModel? GetElement(ScientificWorkSearchModel model);

		ScientificWorkViewModel? Insert(ScientificWorkBindingModel model);

		ScientificWorkViewModel? Update(ScientificWorkBindingModel model);

		ScientificWorkViewModel? Delete(ScientificWorkBindingModel model);
	}
}
