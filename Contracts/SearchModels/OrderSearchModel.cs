using DataModels.Models;
using DataModels.Enums;

namespace Contracts.SearchModels
{
	public class OrderSearchModel
	{
		public int? Id { get; set; }
		public int? TeacherId { get; set; }
		public OrderType? Type { get; set; }
		public DateTime? Date { get; set; }
		public string? OrderNumber { get; set; } 
	}
}
