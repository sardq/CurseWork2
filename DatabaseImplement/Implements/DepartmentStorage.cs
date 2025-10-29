using Contracts.ViewModels;
using Contracts.BindingModels;
using Contracts.SearchModels;
using DatabaseImplement;
using Microsoft.EntityFrameworkCore;
using DatabaseImplement.Models;

namespace Contracts.StorageContracts
{
	public class DepartmentStorage : IDepartmentStorage
	{
		public List<DepartmentViewModel> GetFullList()
		{
			using var context = new Database();
			return context.Departments
				.Include(x => x.Teachers)
				.ThenInclude(x => x.Teacher)
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public List<DepartmentViewModel> GetFilteredList(DepartmentSearchModel model)
		{

			using var context = new Database();
			if (!string.IsNullOrEmpty(model.Name))
				return context.Departments
					.Include(x => x.Teachers)
					.ThenInclude(x => x.Teacher)
					.Where(y => (y.Name == model.Name))
					.Select(x => x.GetViewModel)
					.ToList();
			return context.Departments
				.Include(x => x.Teachers)
				.ThenInclude(x => x.Teacher)
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public DepartmentViewModel? GetElement(DepartmentSearchModel model)
		{
			using var context = new Database();
			if (!string.IsNullOrEmpty(model.Name))
			{
				return context.Departments.Include(x => x.Teachers).ThenInclude(x => x.Teacher)
					 .FirstOrDefault(x => (x.Name == model.Name))
					 ?.GetViewModel;
			}
			return context.Departments.Include(x => x.Teachers).ThenInclude(x => x.Teacher)
					.FirstOrDefault(x => (model.Id.HasValue && x.Id == model.Id))
					?.GetViewModel;
		}

		public DepartmentViewModel? Insert(DepartmentBindingModel model)
		{
			using var context = new Database();
			var newDepartment = Department.Create(context, model);
			if (newDepartment == null)
			{
				return null;
			}
			context.Departments.Add(newDepartment);
			context.SaveChanges();
			return newDepartment.GetViewModel;
		}

		public DepartmentViewModel? Update(DepartmentBindingModel model, bool updateGood)
		{
			using var context = new Database();
			using var transaction = context.Database.BeginTransaction();
			try
			{
				var department = context.Departments.FirstOrDefault(rec => rec.Id == model.Id);
				if (department == null)
				{
					return null;
				}
				department.Update(model);
				context.SaveChanges();
				if (updateGood == true)
					department.UpdateTeachers(context, model);
				transaction.Commit();
				return department.GetViewModel;
			}
			catch
			{
				transaction.Rollback();
				throw;
			}
		}

		public DepartmentViewModel? Delete(DepartmentBindingModel model)
		{
			using var context = new Database();
			var element = context.Departments
					.Include(x => x.Teachers)
					.ThenInclude(x => x.Teacher)
				.FirstOrDefault(rec => rec.Id == model.Id);
			if (element != null)
			{
				context.Departments.Remove(element);
				context.SaveChanges();
				return element.GetViewModel;
			}
			return null;
		}
	}
}
