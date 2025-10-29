using Contracts.BindingModels;
using Contracts.ViewModels;
using DataModels.Enums;
using DataModels.Models;
using System.ComponentModel.DataAnnotations;


namespace DatabaseImplement.Models
{
	public class Order : IOrderModel
	{
		public int Id { get; private set; }
		[Required]
		public string OrderNumber { get; private set; } = string.Empty;
		[Required]
		public string Description { get; private set; } = string.Empty;
		[Required]
		public int TeacherId { get; private set; }
		public Teacher Teacher { get; private set; }
		[Required]
		public OrderType Type { get; private set; } = OrderType.None;
		[Required]
		public DateTime Date { get; private set; } = DateTime.Now;

		public static Order? Create(OrderBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			return new Order()
			{
				Id = model.Id,
				OrderNumber = model.OrderNumber,
				TeacherId = model.TeacherId,
				Date = model.Date,
				Description = model.Description,
				Type = model.Type,
			};
		}
		public void Update(OrderBindingModel model)
		{
			if (model == null)
			{
				return;
			}
			OrderNumber = model.OrderNumber;
			TeacherId = model.TeacherId;
			Date = model.Date;
			Description = model.Description;
			Type = model.Type;
		}
		public OrderViewModel GetViewModel => new()
		{
			Id = Id,
			OrderNumber = OrderNumber,
			TeacherId = TeacherId,
			TeacherFullname = Teacher == null ? null : Teacher.FullName,
			Date = Date,
			Description = Description,
			Type = Type,

		};
	}
}
