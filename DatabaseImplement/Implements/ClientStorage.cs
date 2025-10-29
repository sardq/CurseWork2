using Contracts.ViewModels;
using Contracts.BindingModels;
using Contracts.SearchModels;
using DatabaseImplement;
using DatabaseImplement.Models;

namespace Contracts.StoragesContracts
{
    public class ClientStorage : IClientStorage
    {
		public List<ClientViewModel> GetFullList()
		{
			using var context = new Database();
			return context.Clients
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public List<ClientViewModel> GetFilteredList(ClientSearchModel model)
		{
			if (string.IsNullOrEmpty(model.Login))
			{
				return new();
			}
			using var context = new Database();
			return context.Clients
					.Where(x => x.Login.Contains(model.Login))
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public ClientViewModel? GetElement(ClientSearchModel model)
		{
			if (string.IsNullOrEmpty(model.Login) && !model.Id.HasValue)
			{
				return null;
			}
			using var context = new Database();
			return context.Clients
					.FirstOrDefault(x => ((!string.IsNullOrEmpty(model.Login) && x.Login == model.Login && string.IsNullOrEmpty(model.Password)) || ((!string.IsNullOrEmpty(model.Password) && x.Password == model.Password) && (!string.IsNullOrEmpty(model.Login) && x.Login == model.Login))) ||
										(model.Id.HasValue && x.Id == model.Id))
					?.GetViewModel;
		}

		public ClientViewModel? Insert(ClientBindingModel model)
		{
			var newClient = Client.Create(model);
			if (newClient == null)
			{
				return null;
			}
			using var context = new Database();
			context.Clients.Add(newClient);
			context.SaveChanges();
			return newClient.GetViewModel;
		}

		public ClientViewModel? Update(ClientBindingModel model)
		{
			using var context = new Database();
			var component = context.Clients.FirstOrDefault(x => x.Id == model.Id);
			if (component == null)
			{
				return null;
			}
			component.Update(model);
			context.SaveChanges();
			return component.GetViewModel;
		}

		public ClientViewModel? Delete(ClientBindingModel model)
		{
			using var context = new Database();
			var element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
			if (element != null)
			{
				context.Clients.Remove(element);
				context.SaveChanges();
				return element.GetViewModel;
			}
			return null;
		}
	}
}