using Contracts.BindingModels;
using Contracts.ViewModels;
using DataModels.Enums;
using DataModels.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseImplement.Models
{
    public class Client : IClientModel
    {
        public int Id { get; private set; }

        [Required]
        public string Login { get; private set; } = string.Empty;
        [Required]
        public string Email { get; private set; } = string.Empty;
        [Required]
        public string Password { get; private set; } = string.Empty;

        public ClientRole Role { get; private set; } = ClientRole.None;


        public static Client? Create(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new Client()
            {
                Id = model.Id,
                Login = model.Login,
                Email= model.Email,
                Password = model.Password,
                Role = model.Role,
            };
        }

        public static Client Create(ClientViewModel model)
        {
            return new Client
            {
                Id = model.Id,
                Login = model.Login,
                Email = model.Email,
                Password = model.Password,
                Role = model.Role,
            };
        }

        public void Update(ClientBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            Email = model.Email;
            Password = model.Password;
        }

        public ClientViewModel GetViewModel => new()
        {
            Id = Id,
            Login = Login,
            Email = Email,
            Password = Password,
            Role = Role,
        };
    }
}