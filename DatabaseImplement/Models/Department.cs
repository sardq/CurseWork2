using Contracts.BindingModels;
using Contracts.ViewModels;
using DataModels.Models;
using DatabaseImplement;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DatabaseImplement.Models
{
	public class Department : IDepartmentModel
	{
		public int Id { get; private set; }

		[Required]
		public string Name { get; private set; } = string.Empty;

		[Required]
		public string Address { get; private set; } = string.Empty;
		private Dictionary<int, ITeacherModel> _departmentTeachers = null;
		[NotMapped]
		public Dictionary<int, ITeacherModel> DepartmentTeachers
		{
			get
			{
				if (_departmentTeachers == null)
				{
					_departmentTeachers = Teachers
							.ToDictionary(
							rec => rec.TeacherId,
							rec => (ITeacherModel)rec.Teacher
						);
				}
				return _departmentTeachers;
			}
		}
		[ForeignKey("DepartmentId")]
		public virtual List<DepartmentTeacher> Teachers { get; private set; } = new();
		public static Department Create(Database context, DepartmentBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			return new Department()
			{
				Id = model.Id,
				Name = model.Name,
				Address = model.Address,
				Teachers = model.DepartmentTeachers.Select(x => new DepartmentTeacher
                {
                    Teacher = context.Teachers.First(y => y.Id == x.Key)
                }).ToList(),
			};
		}
		public void Update(DepartmentBindingModel model)
		{
			if (model == null)
			{
				return;
			}
			Name = model.Name;
			Address = model.Address;
		}

		public DepartmentViewModel GetViewModel => new()
		{
			Id = Id,
			Name = Name,
			Address = Address,
			DepartmentTeachers = DepartmentTeachers,
		};
		public void UpdateTeachers(Database context, DepartmentBindingModel model)
		{
			var currentTeachers = context.DepartmentTeachers.Where(rec => rec.DepartmentId == model.Id).ToList();
			context.DepartmentTeachers.RemoveRange(
				currentTeachers.Where(rec => !model.DepartmentTeachers.ContainsKey(rec.TeacherId))
			);

			context.SaveChanges();
			var department = context.Departments.First(x => x.Id == Id);
			foreach (var pair in model.DepartmentTeachers)
			{
				if (!currentTeachers.Any(x => x.TeacherId == pair.Key))
				{
					context.DepartmentTeachers.Add(new DepartmentTeacher
					{
						Department = department,
						Teacher = context.Teachers.First(x => x.Id == pair.Key)
					});
				}
			}

			context.SaveChanges();
			_departmentTeachers = null;
		}
	}
}
