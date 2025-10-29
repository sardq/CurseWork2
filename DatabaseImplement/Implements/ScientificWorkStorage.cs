using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.ViewModels;
using DatabaseImplement;
using DatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace Contracts.StorageContracts
{
	public class ScientificWorkStorage : IScientificWorkStorage
	{
		public List<ScientificWorkViewModel> GetFullList()
		{
			using var context = new Database();
			return context.ScientificWorks
					.Include(x => x.Teacher)
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public List<ScientificWorkViewModel> GetFilteredList(ScientificWorkSearchModel model)
		{
			using var context = new Database();
			var query = context.ScientificWorks.Include(x => x.Teacher).AsQueryable();

			if (!string.IsNullOrEmpty(model.Name))
				query = query.Where(x => x.Name.Contains(model.Name));

			if (model.Year.HasValue)
				query = query.Where(x => x.Year == model.Year);

			if (model.TeacherId.HasValue)
				query = query.Where(x => x.TeacherId == model.TeacherId);

			return query.Select(x => x.GetViewModel).ToList();
		}

		public ScientificWorkViewModel? GetElement(ScientificWorkSearchModel model)
		{
			if (!model.Id.HasValue)
			{
				return null;
			}
			using var context = new Database();
			return context.ScientificWorks
				   .Include(x => x.Teacher)
					.FirstOrDefault(x => ((model.Id.HasValue && x.Id == model.Id)))
					?.GetViewModel;
		}

		public ScientificWorkViewModel? Insert(ScientificWorkBindingModel model)
		{
			using var context = new Database();
			var newScientificWork = ScientificWork.Create(model);
			if (newScientificWork == null)
			{
				return null;
			}
			context.ScientificWorks.Add(newScientificWork);
			context.SaveChanges();
			return newScientificWork.GetViewModel;
		}
		public ScientificWorkViewModel? Update(ScientificWorkBindingModel model)
		{
			using var context = new Database();
			var scientificWork = context.ScientificWorks.FirstOrDefault(x => x.Id == model.Id);
			if (scientificWork == null)
			{
				return null;
			}
			scientificWork.Update(model);
			context.SaveChanges();
			return scientificWork.GetViewModel;
		}

		public ScientificWorkViewModel? Delete(ScientificWorkBindingModel model)
		{
			using var context = new Database();
			var element = context.ScientificWorks.Include(x => x.Teacher).FirstOrDefault(rec => rec.Id == model.Id);
			if (element != null)
			{
				context.ScientificWorks.Remove(element);
				context.SaveChanges();
				return element.GetViewModel;
			}
			return null;
		}
	}
}
