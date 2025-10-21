using DataModels.Enums;
using DataModels.Models;
using System.ComponentModel;

namespace Contracts.ViewModels
{
	public class TeacherViewModel : ITeacherModel
	{
		public int Id { get; set; }
		[DisplayName("ФИО")]
		public string FullName { get; set; } = string.Empty;
		[DisplayName("Ученая степень")]
		public AcademicDegreeEnum AcademicDegree { get; set; } = AcademicDegreeEnum.None;
		[DisplayName("Ставка")]
		public decimal Rate { get; set; }
		[DisplayName("Должность")]
		public TeacherPositionEnum Position { get; set; } = TeacherPositionEnum.None;
		[DisplayName("Категория")]
		public TeacherCategoryEnum Category { get; set;} = TeacherCategoryEnum.None;
		public int DepartmentId { get; set; }
		[DisplayName("Наименование кафедры")]
		public string DepartmentName { get; set; } = string.Empty;
	}
}
