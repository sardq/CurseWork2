using Contracts.BindingModels;
using Contracts.BusinessLogicContracts;
using Contracts.SearchModels;
using Contracts.StorageContracts;
using Contracts.ViewModels;
using DataModels.Enums;
using Microsoft.Extensions.Logging;

namespace BuisinessLogic.BusinessLogic
{
	public class OrderLogic : IOrderLogic
	{
		private readonly ILogger _logger;

		private readonly IOrderStorage _orderStorage;

		public OrderLogic(ILogger<OrderLogic> logger, IOrderStorage orderStorage)
		{
			_logger = logger;
			_orderStorage = orderStorage;
		}

		public List<OrderViewModel>? ReadList(OrderSearchModel? model)
		{
			_logger.LogInformation("ReadList. OrderNumber:{OrderNumber}. Id:{Id}", model?.OrderNumber, model?.Id);
			var list = model == null ? _orderStorage.GetFullList() : _orderStorage.GetFilteredList(model);
			if (list == null)
			{
				_logger.LogWarning("ReadList return null list");
				return null;
			}
			_logger.LogInformation("ReadList. Count:{Count}", list.Count);
			return list;
		}

		public OrderViewModel? ReadElement(OrderSearchModel model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			_logger.LogInformation("ReadElement. OrderNumber:{OrderNumber}. Id:{Id}", model.OrderNumber, model.Id);
			var element = _orderStorage.GetElement(model);
			if (element == null)
			{
				_logger.LogWarning("ReadElement element not found");
				return null;
			}
			_logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
			return element;
		}

		public bool Create(OrderBindingModel model)
		{
			CheckModel(model);
			if (_orderStorage.Insert(model) == null)
			{
				_logger.LogWarning("Insert operation failed");
				return false;
			}
			return true;
		}

		public bool Update(OrderBindingModel model)
		{
			CheckModel(model);
			if (_orderStorage.Update(model) == null)
			{
				_logger.LogWarning("Update operation failed");
				return false;
			}
			return true;
		}

		public bool Delete(OrderBindingModel model)
		{
			CheckModel(model, false);
			_logger.LogInformation("Delete. Id:{Id}", model.Id);
			if (_orderStorage.Delete(model) == null)
			{
				_logger.LogWarning("Delete operation failed");
				return false;
			}
			return true;
		}

		private void CheckModel(OrderBindingModel model, bool withParams = true)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			if (!withParams)
			{
				return;
			}
			if (string.IsNullOrEmpty(model.OrderNumber))
			{
				throw new ArgumentNullException("Нет номера приказа", nameof(model.OrderNumber));
			}
			if (string.IsNullOrEmpty(model.Description))
			{
				throw new ArgumentNullException("Нет описания приказа", nameof(model.Description));
			}
			if (model.Date.Year < 1900 || model.Date > DateTime.Now)
			{
				throw new ArgumentException("Неправильный год", nameof(model.Date));
			}
			if (model.Type == OrderType.None)
			{
				throw new ArgumentException("Нет типа приказа", nameof(model.Type));
			}
			_logger.LogInformation("Order. OrderNumber:{OrderNumber}. Description:{Description}. Date:{Date}. Type:{Type}.", model.OrderNumber, model.Description, model.Date, model.Type);
			var element = _orderStorage.GetElement(new OrderSearchModel
			{
				OrderNumber = model.OrderNumber,

			});
			if (element != null && element.Id != model.Id)
			{
				throw new InvalidOperationException("Приказ с такими данными уже есть");
			}
		}
	}
}
