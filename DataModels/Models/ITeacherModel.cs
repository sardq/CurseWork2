namespace DataModels.Models
{
	public interface ITeacherModel : IId
	{
		string FullName { get; }
		string AcademicDegree { get; }
		decimal Rate { get; }
		string Position { get; }
		string Category { get; }
		int DepartmentId { get; }
	}
}
