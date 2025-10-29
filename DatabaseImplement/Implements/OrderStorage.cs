using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.ViewModels;
using DatabaseImplement;
using DatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace Contracts.StorageContracts
{
	public class OrderStorage : IOrderStorage
	{
		public List<OrderViewModel> GetFullList()
		{
			using var context = new Database();
			return context.Orders
					.Include(x => x.Teacher)
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public List<OrderViewModel> GetFilteredList(OrderSearchModel model)
		{
			using var context = new Database();
			var query = context.Orders.Include(x => x.Teacher).AsQueryable();

			if (model.Type != DataModels.Enums.OrderType.None)
				query = query.Where(x => x.Type == model.Type);
			if (model.TeacherId.HasValue)
				query = query.Where(x => x.TeacherId == model.TeacherId);
			return query.Select(x => x.GetViewModel).ToList();
		}

		public OrderViewModel? GetElement(OrderSearchModel model)
		{
			if (!model.Id.HasValue)
			{
				return null;
			}
			using var context = new Database();
			return context.Orders
				   .Include(x => x.Teacher)
					.FirstOrDefault(x => ((model.Id.HasValue && x.Id == model.Id)))
					?.GetViewModel;
		}

		public OrderViewModel? Insert(OrderBindingModel model)
		{
			using var context = new Database();
			var newOrder = Order.Create(model);
			if (newOrder == null)
			{
				return null;
			}
			context.Orders.Add(newOrder);
			context.SaveChanges();
			return newOrder.GetViewModel;
		}
		public OrderViewModel? Update(OrderBindingModel model)
		{
			using var context = new Database();
			var order = context.Orders.FirstOrDefault(x => x.Id == model.Id);
			if (order == null)
			{
				return null;
			}
			order.Update(model);
			context.SaveChanges();
			return order.GetViewModel;
		}

		public OrderViewModel? Delete(OrderBindingModel model)
		{
			using var context = new Database();
			var element = context.Orders.Include(x => x.Teacher).FirstOrDefault(rec => rec.Id == model.Id);
			if (element != null)
			{
				context.Orders.Remove(element);
				context.SaveChanges();
				return element.GetViewModel;
			}
			return null;
		}
	}
}
