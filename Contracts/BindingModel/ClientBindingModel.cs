using DataModels.Enums;
using DataModels.Models;

namespace Contracts.BindingModels
{
    public class ClientBindingModel : IClientModel
    {
        public int Id { get; set; }

        public string Login { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
        public ClientRole Role { get; set; } = ClientRole.None;
    }
}