using DataModels.Enums;
using DataModels.Models;
using System.ComponentModel;

namespace Contracts.ViewModels
{
    public class ClientViewModel : IClientModel
    {
        public int Id { get; set; }

        [DisplayName("Логин")]
        public string Login { get; set; } = string.Empty;

        [DisplayName("Электронная почта")]
        public string Email { get; set; } = string.Empty;

        [DisplayName("Пароль")]
        public string Password { get; set; } = string.Empty;

        [DisplayName("Роль")]
        public ClientRole Role { get; set; } = ClientRole.None;
    }
}