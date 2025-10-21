using DataModels.Enums;

namespace DataModels.Models
{
	public interface IParticipantModel : IId
	{
		int ScientificWorkId { get; }
		int TeacherId { get; }
		ParticipantRole Role { get; }
	}
}
