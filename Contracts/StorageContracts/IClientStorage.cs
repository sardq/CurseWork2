using Contracts.ViewModels;
using Contracts.BindingModels;
using Contracts.SearchModels;

namespace Contracts.StoragesContracts
{
    public interface IClientStorage
    {
        List<ClientViewModel> GetFullList();

        List<ClientViewModel> GetFilteredList(ClientSearchModel model);

        ClientViewModel? GetElement(ClientSearchModel model);

        ClientViewModel? Insert(ClientBindingModel model);

        ClientViewModel? Update(ClientBindingModel model);

        ClientViewModel? Delete(ClientBindingModel model);
    }
}