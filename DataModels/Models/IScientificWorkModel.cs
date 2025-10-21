using DataModels.Enums;

namespace DataModels.Models
{
	public interface IScientificWorkModel : IId
	{
		string Name { get; }
		int TeacherId { get; }
		int Year { get; }
		ScientificWorkStatus Status { get; }
		ScientificWorkType Type { get; }
		decimal? FundingAmount { get; }
	}
}
