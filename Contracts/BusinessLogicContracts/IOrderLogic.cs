using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.ViewModels;

namespace Contracts.BusinessLogicContracts
{
	public interface IOrderLogic
	{
		List<OrderViewModel>? ReadList(OrderSearchModel? model);

		OrderViewModel? ReadElement(OrderSearchModel model);

		bool Create(OrderBindingModel model);

		bool Update(OrderBindingModel model);

		bool Delete(OrderBindingModel model);
	}
}
