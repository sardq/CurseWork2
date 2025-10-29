using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.ViewModels;
using DatabaseImplement;
using DatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace Contracts.StorageContracts
{
	public class TeacherStorage: ITeacherStorage
	{
		public List<TeacherViewModel> GetFullList()
		{
			using var context = new Database();
			return context.Teachers
					.Include(x => x.Department)
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public List<TeacherViewModel> GetFilteredList(TeacherSearchModel model)
		{
			using var context = new Database();
			var query = context.Teachers.Include(x => x.Department).AsQueryable();

			if (!string.IsNullOrEmpty(model.FullName))
				query = query.Where(x => x.FullName.Contains(model.FullName));

			if (model.DepartmentId.HasValue)
				query = query.Where(x => x.DepartmentId == model.DepartmentId);

			return query.Select(x => x.GetViewModel).ToList();
		}

		public TeacherViewModel? GetElement(TeacherSearchModel model)
		{
			if (!model.Id.HasValue)
			{
				return null;
			}
			using var context = new Database();
			return context.Teachers
				   .Include(x => x.Department)
					.FirstOrDefault(x => ((model.Id.HasValue && x.Id == model.Id)))
					?.GetViewModel;
		}

		public TeacherViewModel? Insert(TeacherBindingModel model)
		{
			using var context = new Database();
			var newTeacher = Teacher.Create(model);
			if (newTeacher == null)
			{
				return null;
			}
			context.Teachers.Add(newTeacher);
			context.SaveChanges();
			return newTeacher.GetViewModel;
		}
		public TeacherViewModel? Update(TeacherBindingModel model)
		{
			using var context = new Database();
			var teacher = context.Teachers.FirstOrDefault(x => x.Id == model.Id);
			if (teacher == null)
			{
				return null;
			}
			teacher.Update(model);
			context.SaveChanges();
			return teacher.GetViewModel;
		}

		public TeacherViewModel? Delete(TeacherBindingModel model)
		{
			using var context = new Database();
			var element = context.Teachers.Include(x => x.Department).FirstOrDefault(rec => rec.Id == model.Id);
			if (element != null)
			{
				context.Teachers.Remove(element);
				context.SaveChanges();
				return element.GetViewModel;
			}
			return null;
		}
	}
}
