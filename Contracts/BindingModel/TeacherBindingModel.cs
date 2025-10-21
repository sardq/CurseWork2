using DataModels.Models;
using DataModels.Enums;

namespace Contracts.BindingModels
{
	public class TeacherBindingModel : ITeacherModel
	{
		public int Id { get; set; }
		public string FullName { get; set; } = string.Empty;
		public AcademicDegreeEnum AcademicDegree { get; set; } = AcademicDegreeEnum.None;
		public decimal Rate { get; set; }
		public TeacherPositionEnum Position { get; set; } = TeacherPositionEnum.None;
		public TeacherCategoryEnum Category { get; set;} = TeacherCategoryEnum.None;
		public int DepartmentId { get; set; }
	}
}
