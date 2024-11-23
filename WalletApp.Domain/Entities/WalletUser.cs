using WalletApp.Domain.Common;

namespace WalletApp.Domain.Entities
{
    public class WalletUser : BaseEntity
    {
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Email { get;  set; }
        public string PhoneNumber { get;  set; }
        public string Address { get;  set; }
        public DateTime DateOfBirth { get;  set; }
    }
}