using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.ViewModels;

namespace Contracts.StorageContracts
{
	public interface ITeacherStorage
	{
		List<TeacherViewModel> GetFullList();

		List<TeacherViewModel> GetFilteredList(TeacherSearchModel model);

		TeacherViewModel? GetElement(TeacherSearchModel model);

		TeacherViewModel? Insert(TeacherBindingModel model);

		TeacherViewModel? Update(TeacherBindingModel model);

		TeacherViewModel? Delete(TeacherBindingModel model);
	}
}
