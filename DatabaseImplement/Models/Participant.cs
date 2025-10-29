using Contracts.BindingModels;
using Contracts.ViewModels;
using DataModels.Enums;
using DataModels.Models;
using System.ComponentModel.DataAnnotations;

namespace DatabaseImplement.Models
{
	public class Participant : IParticipantModel
	{
		public int Id { get; private set; }

		[Required]
		public int TeacherId { get; private set; }

		public Teacher Teacher { get; private set; }
		[Required]
		public int ScientificWorkId { get; private set; }

		public ScientificWork ScientificWork { get; private set; }
		[Required]
		public ParticipantRole Role { get; private set; } = ParticipantRole.None;

		public static Participant? Create(ParticipantBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			return new Participant()
			{
				Id = model.Id,
				ScientificWorkId = model.ScientificWorkId,
				TeacherId = model.TeacherId,
				Role = model.Role,
			};
		}
		public void Update(ParticipantBindingModel model)
		{
			if (model == null)
			{
				return;
			}
			ScientificWorkId = model.ScientificWorkId;
			TeacherId = model.TeacherId;
			Role = model.Role;
		}
		public ParticipantViewModel GetViewModel => new()
		{
			Id = Id,
			TeacherId = TeacherId,
			TeacherFullname = Teacher == null ? null : Teacher.FullName,
			ScientificWorkId = ScientificWorkId,
			ScientificWorkName = ScientificWork == null ? null : ScientificWork.Name,
			Role = Role,

		};
	}
}
