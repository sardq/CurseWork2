using DataModels.Models;
using DataModels.Enums;

namespace Contracts.BindingModels
{
	public class OrderBindingModel : IOrderModel
	{
		public int Id { get; set; }
		public int TeacherId { get; set; }
		public OrderType Type { get; set; } = OrderType.None;
		public DateTime Date { get; set; }
		public string OrderNumber { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
	}
}
