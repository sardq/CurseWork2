using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.ViewModels;

namespace Contracts.BusinessLogicContracts
{
	public interface IScientificWorkLogic 
	{
		List<ScientificWorkViewModel>? ReadList(ScientificWorkSearchModel? model);

		ScientificWorkViewModel? ReadElement(ScientificWorkSearchModel model);

		bool Create(ScientificWorkBindingModel model);

		bool Update(ScientificWorkBindingModel model);

		bool Delete(ScientificWorkBindingModel model);
	}
}
