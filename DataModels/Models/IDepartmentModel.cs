namespace DataModels.Models
{
	public interface IDepartmentModel : IId
	{
		string Name { get; }
		Dictionary<int, ITeacherModel> DepartmentTeachers { get; }
		string Address { get; }
	}
}
