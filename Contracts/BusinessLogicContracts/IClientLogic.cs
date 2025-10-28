using Contracts.BindingModels;
using Contracts.SearchModels;
using Contracts.ViewModels;

namespace Contracts.BusinessLogicsContracts
{
    public interface IClientLogic
    {
        List<ClientViewModel>? ReadList(ClientSearchModel? model);

        ClientViewModel? ReadElement(ClientSearchModel model);

        bool Create(ClientBindingModel model);

        bool Update(ClientBindingModel model);

        bool Delete(ClientBindingModel model);
    }
}