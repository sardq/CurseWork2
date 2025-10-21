using DataModels.Enums;
using DataModels.Models;
using System.ComponentModel;

namespace Contracts.ViewModels
{
	public class ScientificWorkViewModel : IScientificWorkModel
	{
		public int Id { get; set; }
		[DisplayName("Наименование")]
		public string Name { get; set; } = string.Empty;
		public int TeacherId { get; set; }
		[DisplayName("ФИО преподавателя")]
		public string TeacherFullname { get; set; } = string.Empty;
		[DisplayName("Год")]
		public int Year { get; set; }
		[DisplayName("Статус")]
		public ScientificWorkStatus Status { get; set; } = ScientificWorkStatus.Draft;
		[DisplayName("Тип")]
		public ScientificWorkType Type { get; set; } = ScientificWorkType.None;
		[DisplayName("Сумма финансирования")]
		public decimal? FundingAmount { get; set; }
	}
}
