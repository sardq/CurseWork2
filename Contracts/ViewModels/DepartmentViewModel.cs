using DataModels.Enums;
using DataModels.Models;
using System.ComponentModel;

namespace Contracts.ViewModels
{
	public class DepartmentViewModel : IDepartmentModel
	{
		public int Id { get; set; }
		[DisplayName("Название")]
		public string Name { get; set; } = string.Empty;
		[DisplayName("Преподаватели")]
		public Dictionary<int, ITeacherModel> DepartmentTeachers { get; set; } = new();
		[DisplayName("Адрес")]
		public string Address { get; set; } = string.Empty;
	}
}
