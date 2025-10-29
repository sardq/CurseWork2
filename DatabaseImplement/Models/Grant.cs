using System.ComponentModel.DataAnnotations;
using DataModels.Models;
using DataModels.Enums;
using Contracts.BindingModels;
using Contracts.ViewModels;

namespace DatabaseImplement.Models
{
	public class Grant : IGrantModel
	{
		public int Id { get; private set; }
		[Required]
		public string Name { get; private set; } = string.Empty;

		[Required]
		public int TeacherId { get; private set; }

		public Teacher Teacher { get; private set; }
		[Required]
		public int Year { get; private set; }
		[Required]
		public decimal Amount { get; private set; }
		[Required]
		public GrantStatus Status { get; private set; } = GrantStatus.Draft;
		[Required]
		public GrantTypeEnum Type { get; private set; } = GrantTypeEnum.None;

		public static Grant? Create(GrantBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			return new Grant()
			{
				Id = model.Id,
				Name = model.Name,
				TeacherId = model.TeacherId,
				Year = model.Year,
				Amount = model.Amount,
				Status = model.Status,
				Type = model.Type,
			};
		}
		public void Update(GrantBindingModel model)
		{
			if (model == null)
			{
				return;
			}
			Name = model.Name;
			TeacherId = model.TeacherId;
			Year = model.Year;
			Amount = model.Amount;
			Status = model.Status;
			Type = model.Type;
		}
		public GrantViewModel GetViewModel => new()
		{
			Id = Id,
			Name = Name,
			TeacherId = TeacherId,
			TeacherFullname = Teacher == null ? null : Teacher.FullName,
			Year = Year,
			Amount = Amount,
			Status = Status,
			Type = Type,

		};
	}
}
