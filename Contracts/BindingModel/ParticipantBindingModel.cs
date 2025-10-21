using DataModels.Models;
using DataModels.Enums;

namespace Contracts.BindingModels
{
	public class ParticipantBindingModel : IParticipantModel
	{
		public int Id { get; set; }
		public int ScientificWorkId { get; set; }
		public int TeacherId { get; set; }
		public ParticipantRole Role { get; set; } = ParticipantRole.None;
	}
}
