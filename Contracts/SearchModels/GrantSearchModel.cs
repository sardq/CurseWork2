using DataModels.Enums;

namespace Contracts.SearchModels
{
	public class GrantSearchModel
	{
		public int? Id { get; set; }
		public string? Name { get; set; }
		public int? Year { get; set; }
		public GrantStatus? Status { get; set; }
		public GrantTypeEnum? Type { get; set; }
	}
}
