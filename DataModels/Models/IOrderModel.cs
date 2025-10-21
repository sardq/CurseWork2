using DataModels.Enums;

namespace DataModels.Models
{
	public interface IOrderModel : IId
	{
		int TeacherId { get; }
		OrderType Type { get; }
		DateTime Date { get; }
		string OrderNumber { get; }
		string Description { get; }
	}
}
