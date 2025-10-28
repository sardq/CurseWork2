using DataModels.Enums;

namespace DataModels.Models
{
    public interface IClientModel : IId
    {
        string Login { get; }

        string Email { get; }

        string Password { get; }

        ClientRole Role { get; }
    }
}
