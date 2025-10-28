using DataModels.Enums;

namespace Contracts.SearchModels
{
    public class ClientSearchModel
    {
        public int? Id { get; set; }

        public string? Login { get; set; }

        public string? Password { get; set; }

        public ClientRole? Role { get; set; }
    }
}