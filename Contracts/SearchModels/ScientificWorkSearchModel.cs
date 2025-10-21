using DataModels.Models;
using DataModels.Enums;

namespace Contracts.SearchModels
{
	public class ScientificWorkSearchModel
	{
		public int? Id { get; set; }
		public string? Name { get; set; } 
		public int? TeacherId { get; set; }
		public int? Year { get; set; }
		public ScientificWorkStatus? Status { get; set; } 
		public ScientificWorkType? Type { get; set; }
	}
}
