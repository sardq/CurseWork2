using DataModels.Enums;
using DataModels.Models;
using System.ComponentModel;

namespace Contracts.ViewModels
{
	public class ParticipantViewModel : IParticipantModel
	{
		public int Id { get; set; }
		public int ScientificWorkId { get; set; }
		[DisplayName("Наименование научной работы")]
		public string ScientificWorkName { get; set; } = string.Empty;
		public int TeacherId { get; set; }
		[DisplayName("ФИО участника")]
		public string TeacherFullname { get; set; } = string.Empty;

		[DisplayName("Роль")]
		public ParticipantRole Role { get; set; } = ParticipantRole.None;
	}
}
