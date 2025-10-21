using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.ViewModels;
using DataModels.Models;

namespace Contracts.StorageContracts
{
	public interface IGrantStorage
	{
		List<GrantViewModel> GetFullList();

		List<GrantViewModel> GetFilteredList(GrantSearchModel model);

		GrantViewModel? GetElement(GrantSearchModel model);

		GrantViewModel? Insert(GrantBindingModel model);

		GrantViewModel? Update(GrantBindingModel model);

		GrantViewModel? Delete(GrantBindingModel model);
	}
}
