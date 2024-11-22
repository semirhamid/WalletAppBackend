using WalletApp.Domain.Common;

namespace WalletApp.Domain.Entities
{
    public class WalletUser : BaseEntity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Address { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        public WalletUser(string firstName, string lastName, string email, string phoneNumber, string address, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            DateOfBirth = dateOfBirth;
        }
    }
}