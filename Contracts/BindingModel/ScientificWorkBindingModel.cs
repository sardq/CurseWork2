using DataModels.Models;
using DataModels.Enums;

namespace Contracts.BindingModels
{
	public class ScientificWorkBindingModel : IScientificWorkModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public int TeacherId { get; set; }
		public int Year { get; set; }
		public ScientificWorkStatus Status { get; set; } = ScientificWorkStatus.Draft;
		public ScientificWorkType Type { get; set; } = ScientificWorkType.None;
		public decimal? FundingAmount { get; set; }
	}
}
