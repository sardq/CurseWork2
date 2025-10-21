using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.ViewModels;

namespace Contracts.BusinessLogicContracts
{
	public interface ITeacherLogic
	{
		List<TeacherViewModel>? ReadList(TeacherSearchModel? model);

		TeacherViewModel? ReadElement(TeacherSearchModel model);
		TeacherCardViewModel? ReadCard(TeacherSearchModel model);

		bool Create(TeacherBindingModel model);

		bool Update(TeacherBindingModel model);

		bool Delete(TeacherBindingModel model);
	}
}
