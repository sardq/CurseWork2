using DataModels.Models;

namespace Contracts.BindingModels
{
	public class DepartmentBindingModel : IDepartmentModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public Dictionary<int, ITeacherModel> DepartmentTeachers { get; set; } = new();
		public string Address { get; set; } = string.Empty;
	}
}
