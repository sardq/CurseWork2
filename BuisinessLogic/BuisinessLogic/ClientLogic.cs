using Contracts.BindingModels;
using Contracts.BusinessLogicsContracts;
using Contracts.SearchModels;
using Contracts.StoragesContracts;
using Contracts.ViewModels;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace ElectronicShopBusinessLogic.BusinessLogics
{
    public class ClientLogic : IClientLogic
    {
        private readonly ILogger _logger;

        private readonly IClientStorage _clientStorage;

        public ClientLogic(ILogger<ClientLogic> logger, IClientStorage clientStorage)
        {
            _logger = logger;
            _clientStorage = clientStorage;
        }

        public List<ClientViewModel>? ReadList(ClientSearchModel? model)
        {
            _logger.LogInformation("ReadList. Login:{Login}. Id:{Id}", model?.Login, model?.Id);
            var list = model == null ? _clientStorage.GetFullList() : _clientStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }

        public ClientViewModel? ReadElement(ClientSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadElement. Login:{Login}. Id:{Id}", model.Login, model.Id);
            var element = _clientStorage.GetElement(model);
            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }
            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
            return element;
        }

        public bool Create(ClientBindingModel model)
        {
            CheckModel(model);
            if (_clientStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }

        public bool Update(ClientBindingModel model)
        {
            CheckModel(model);
            if (_clientStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }
            return true;
        }

        public bool Delete(ClientBindingModel model)
        {
            CheckModel(model, false);
            _logger.LogInformation("Delete. Id:{Id}", model.Id);
            if (_clientStorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");
                return false;
            }
            return true;
        }

        private void CheckModel(ClientBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.Login))
            {
                throw new ArgumentNullException("Нет логина клиента", nameof(model.Login));
            }
            if (string.IsNullOrEmpty(model.Email) || !Regex.IsMatch(model.Email, @"^[a-z0-9._%+-]+\@([a-z0-9-]+\.)+[a-z]{2,4}$"))
            {
                throw new ArgumentException("Почта не соответствует требованиям", nameof(model.Email));
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                throw new ArgumentNullException("Нет пароля клиента", nameof(model.Email));
            }
            _logger.LogInformation("Client. Login:{Login}. Email:{Email}. Password:{Password}.", model.Login, model.Email, model.Password);
            var element = _clientStorage.GetElement(new ClientSearchModel
            {
                 Login = model.Login,

            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Клиент с такими данными уже есть");
            }
        }
    }
}