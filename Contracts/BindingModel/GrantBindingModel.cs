using DataModels.Models;
using DataModels.Enums;

namespace Contracts.BindingModels
{
	public class GrantBindingModel : IGrantModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public int TeacherId { get; set; }
		public int Year { get; set; }
		public decimal Amount { get; set; }
		public GrantStatus Status { get; set; } = GrantStatus.Draft;
		public GrantTypeEnum Type { get; set; } = GrantTypeEnum.Other;
	}
}
