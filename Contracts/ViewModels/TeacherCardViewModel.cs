using DataModels.Enums;
using Contracts.BindingModels;
using System.ComponentModel;

namespace Contracts.ViewModels
{
    public class TeacherCardViewModel
    {
		public int Id { get; set; }

		[DisplayName("ФИО")]
		public string FullName { get; set; } = string.Empty;

		[DisplayName("Учёная степень")]
		public AcademicDegreeEnum AcademicDegree { get; set; } = AcademicDegreeEnum.None;

		[DisplayName("Должность")]
		public TeacherPositionEnum Position { get; set; } = TeacherPositionEnum.None;

		[DisplayName("Категория")]
		public TeacherCategoryEnum Category { get; set; } = TeacherCategoryEnum.None;

		[DisplayName("Ставка")]
		public decimal Rate { get; set; }
		public int DepartmentId { get; set; }
		[DisplayName("Наименование кафедры")]
		public string DepartmentName { get; set; } = string.Empty;

		[DisplayName("Приказы")]
		public Dictionary<int, (OrderBindingModel, string)> Orders { get; set; } = new();

		[DisplayName("Научные работы / гранты")]
		public Dictionary<int, (ScientificWorkBindingModel, string)> ScientificWorks { get; set; } = new();
	}
}
