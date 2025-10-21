using DataModels.Enums;

namespace DataModels.Models
{
	public interface IGrantModel : IId
	{
		string Name { get; }
		int TeacherId { get; }
		int Year { get; }
		decimal Amount { get; }
		GrantStatus Status { get; }
		GrantTypeEnum Type { get; }
	}
}
