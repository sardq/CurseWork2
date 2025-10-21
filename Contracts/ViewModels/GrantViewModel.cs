using DataModels.Enums;
using DataModels.Models;
using System.ComponentModel;

namespace Contracts.ViewModels
{
	public class GrantViewModel : IGrantModel
	{
		public int Id { get; set; }
		[DisplayName("Наименование")]
		public string Name { get; set; } = string.Empty;
		public int TeacherId { get; set; }
		[DisplayName("ФИО преподавателя")]
		public string TeacherFullname { get; set; } = string.Empty;

		[DisplayName("Год")]
		public int Year { get; set; }
		[DisplayName("Количество")]

		public decimal Amount { get; set; }
		[DisplayName("Статус")]

		public GrantStatus Status { get; set; } = GrantStatus.Draft;
		[DisplayName("Тип")]
		public GrantTypeEnum Type { get; set; } = GrantTypeEnum.Other;
	}
}
