using Contracts.ViewModels;
using Contracts.BindingModels;
using Contracts.SearchModels;

namespace Contracts.BusinessLogicContracts
{
	public interface IDepartmentLogic 
	{
		List<DepartmentViewModel>? ReadList(DepartmentSearchModel? model);

		DepartmentViewModel? ReadElement(DepartmentSearchModel model);

		bool Create(DepartmentBindingModel model);

		bool Update(DepartmentBindingModel model, bool updateTeacher);

		bool Delete(DepartmentBindingModel model);
	}
}
