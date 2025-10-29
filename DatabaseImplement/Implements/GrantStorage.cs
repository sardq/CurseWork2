using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.ViewModels;
using DatabaseImplement;
using DatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace Contracts.StorageContracts
{
	public class GrantStorage : IGrantStorage
	{
		public List<GrantViewModel> GetFullList()
		{
			using var context = new Database();
			return context.Grants
					.Include(x => x.Teacher)
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public List<GrantViewModel> GetFilteredList(GrantSearchModel model)
		{
			using var context = new Database();
			var query = context.Grants.Include(x => x.Teacher).AsQueryable();

			if (!string.IsNullOrEmpty(model.Name))
				query = query.Where(x => x.Name.Contains(model.Name));

			if (model.Year.HasValue)
				query = query.Where(x => x.Year == model.Year);

			if (model.TeacherId.HasValue)
				query = query.Where(x => x.TeacherId == model.TeacherId);

			return query.Select(x => x.GetViewModel).ToList();
		}

		public GrantViewModel? GetElement(GrantSearchModel model)
		{
			if (!model.Id.HasValue)
			{
				return null;
			}
			using var context = new Database();
			return context.Grants
				   .Include(x => x.Teacher)
					.FirstOrDefault(x => ((model.Id.HasValue && x.Id == model.Id)))
					?.GetViewModel;
		}

		public GrantViewModel? Insert(GrantBindingModel model)
		{
			using var context = new Database();
			var newGrant = Grant.Create(model);
			if (newGrant == null)
			{
				return null;
			}
			context.Grants.Add(newGrant);
			context.SaveChanges();
			return newGrant.GetViewModel;
		}
		public GrantViewModel? Update(GrantBindingModel model)
		{
			using var context = new Database();
			var grant = context.Grants.FirstOrDefault(x => x.Id == model.Id);
			if (grant == null)
			{
				return null;
			}
			grant.Update(model);
			context.SaveChanges();
			return grant.GetViewModel;
		}

		public GrantViewModel? Delete(GrantBindingModel model)
		{
			using var context = new Database();
			var element = context.Grants.Include(x => x.Teacher).FirstOrDefault(rec => rec.Id == model.Id);
			if (element != null)
			{
				context.Grants.Remove(element);
				context.SaveChanges();
				return element.GetViewModel;
			}
			return null;
		}
	}
}
