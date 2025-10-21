using DataModels.Enums;

namespace Contracts.SearchModels
{
	public class TeacherSearchModel 
	{
		public int? Id { get; set; }
		public string? FullName { get; set; } = string.Empty;
		public AcademicDegreeEnum? AcademicDegree { get; set; }
		public TeacherPositionEnum? Position { get; set; }
		public TeacherCategoryEnum? Category { get; set;}
		public int? DepartmentId { get; set; }
	}
}
