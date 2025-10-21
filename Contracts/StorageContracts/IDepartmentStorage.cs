using Contracts.ViewModels;
using Contracts.BindingModels;
using Contracts.SearchModels;

namespace Contracts.StorageContracts
{
	public interface IDepartmentStorage
	{
		List<DepartmentViewModel> GetFullList();

		List<DepartmentViewModel> GetFilteredList(DepartmentSearchModel model);

		DepartmentViewModel? GetElement(DepartmentSearchModel model);

		DepartmentViewModel? Insert(DepartmentBindingModel model);

		DepartmentViewModel? Update(DepartmentBindingModel model);

		DepartmentViewModel? Delete(DepartmentBindingModel model);
	}
}
