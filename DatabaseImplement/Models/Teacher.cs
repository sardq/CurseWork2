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
	public class Teacher : ITeacherModel
	{
		public int Id { get; private set; }
		[Required]
		public string FullName { get; private set; } = string.Empty;
		[Required]
		public int DepartmentId { get; private set; }

		public Department Department { get; private set; }
		[Required]
		public decimal Rate { get; private set; }

		[Required]
		public AcademicDegreeEnum AcademicDegree { get; private set; } = AcademicDegreeEnum.None;
		[Required]
		public TeacherCategoryEnum Category { get; private set; } = TeacherCategoryEnum.None;
		[Required]
		public TeacherPositionEnum Position { get; private set; } = TeacherPositionEnum.None;

		public static Teacher? Create(TeacherBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			return new Teacher()
			{
				Id = model.Id,
				FullName = model.FullName,
				DepartmentId = model.DepartmentId,
				Rate = model.Rate,
				AcademicDegree = model.AcademicDegree,
				Category = model.Category,
				Position = model.Position,
			};
		}
		public void Update(TeacherBindingModel model)
		{
			if (model == null)
			{
				return;
			}
			FullName = model.FullName;
			DepartmentId = model.DepartmentId;
			Rate = model.Rate;
			AcademicDegree = model.AcademicDegree;
			Category = model.Category;
			Position = model.Position;
		}
		public TeacherViewModel GetViewModel => new()
		{
			Id = Id,
			DepartmentId = DepartmentId,
			DepartmentName = Department == null ? null : Department.Name,
			FullName = FullName,
			Rate = Rate,
			AcademicDegree = AcademicDegree,
			Category = Category,
			Position = Position,

		};
	}
}
