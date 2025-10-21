using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.ViewModels;

namespace Contracts.StorageContracts
{
	public interface IOrderStorage
	{
		List<OrderViewModel> GetFullList();

		List<OrderViewModel> GetFilteredList(OrderSearchModel model);

		OrderViewModel? GetElement(OrderSearchModel model);

		OrderViewModel? Insert(OrderBindingModel model);

		OrderViewModel? Update(OrderBindingModel model);

		OrderViewModel? Delete(OrderBindingModel model);
	}
}
