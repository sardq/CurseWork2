using DataModels.Enums;

namespace DataModels.Models
{
	public interface ITeacherModel : IId
	{
		string FullName { get; }
		AcademicDegreeEnum AcademicDegree { get; }
		decimal Rate { get; }
		TeacherPositionEnum Position { get; }
		TeacherCategoryEnum Category { get; }
		int DepartmentId { get; }
	}
}
