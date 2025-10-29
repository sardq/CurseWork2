using Contracts.BindingModels;
using Contracts.ViewModels;
using DataModels.Enums;
using DataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseImplement.Models
{
	public class ScientificWork : IScientificWorkModel
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
		public decimal? FundingAmount { get; private set; }
		[Required]
		public ScientificWorkStatus Status { get; private set; } = ScientificWorkStatus.Draft;
		[Required]
		public ScientificWorkType Type { get; private set; } = ScientificWorkType.None;

		public static ScientificWork? Create(ScientificWorkBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			return new ScientificWork()
			{
				Id = model.Id,
				Name = model.Name,
				TeacherId = model.TeacherId,
				Year = model.Year,
				FundingAmount = model.FundingAmount,
				Status = model.Status,
				Type = model.Type,
			};
		}
		public void Update(ScientificWorkBindingModel model)
		{
			if (model == null)
			{
				return;
			}
			Name = model.Name;
			TeacherId = model.TeacherId;
			Year = model.Year;
			FundingAmount = model.FundingAmount;
			Status = model.Status;
			Type = model.Type;
		}
		public ScientificWorkViewModel GetViewModel => new()
		{
			Id = Id,
			Name = Name,
			TeacherId = TeacherId,
			TeacherFullname = Teacher == null ? null : Teacher.FullName,
			Year = Year,
			FundingAmount = FundingAmount,
			Status = Status,
			Type = Type,

		};
	}
}
