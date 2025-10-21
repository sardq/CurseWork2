using DataModels.Enums;

namespace Contracts.SearchModels
{
	public class ParticipantSearchModel
	{
		public int? Id { get; set; }
		public int? ScientificWorkId { get; set; }
		public int? TeacherId { get; set; }
		public ParticipantRole? Role { get; set; }
	}
}
