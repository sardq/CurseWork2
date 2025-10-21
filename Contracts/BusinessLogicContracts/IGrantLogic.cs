using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.ViewModels;

namespace Contracts.BusinessLogicContracts
{
	public interface IGrantLogic
	{
		List<GrantViewModel>? ReadList(GrantSearchModel? model);

		GrantViewModel? ReadElement(GrantSearchModel model);

		bool Create(GrantBindingModel model);

		bool Update(GrantBindingModel model);

		bool Delete(GrantBindingModel model);
	}
}
