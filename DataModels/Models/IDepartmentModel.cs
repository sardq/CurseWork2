namespace DataModels.Models
{
	public interface IDepartmentModel : IId
	{
		string Name { get; }
		int	TeacherId { get; }
		string Address { get; }
	}
}
