using DataModels.Enums;
using DataModels.Models;
using System.ComponentModel;

namespace Contracts.ViewModels
{
	public class OrderViewModel : IOrderModel
	{
		public int Id { get; set; }
		public int TeacherId { get; set; }
		[DisplayName("ФИО преподавателя")]
		public string TeacherFullname { get; set; } = string.Empty;

		[DisplayName("Тип")]
		public OrderType Type { get; set; } = OrderType.None;
		[DisplayName("Дата")]
		public DateTime Date { get; set; }
		[DisplayName("Номер приказа")]
		public string OrderNumber { get; set; } = string.Empty;
		[DisplayName("Описание")]
		public string Description { get; set; } = string.Empty;
	}
}
