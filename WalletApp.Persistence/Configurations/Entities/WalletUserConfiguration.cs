using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalletApp.Domain.Entities;
using DateTime = System.DateTime;

namespace WalletApp.Infrastructure.Persistence.Configurations.Entities;

public class WalletUserConfiguration : IEntityTypeConfiguration<WalletUser>
{
    public void Configure(EntityTypeBuilder<WalletUser> builder)
    {
        builder.HasData(
            new WalletUser
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Address = "123 Main St",
                PhoneNumber = "123-456-7890",
                DateOfBirth = DateTime.UtcNow
            },
            new WalletUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane.smith@example.com",
                Address = "456 Elm St",
                PhoneNumber = "234-567-8901",
                DateOfBirth = DateTime.UtcNow,
            },
            new WalletUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Alice",
                LastName = "Johnson",
                Email = "alice.johnson@example.com",
                Address = "789 Oak St",
                PhoneNumber = "345-678-9012",
                DateOfBirth = DateTime.UtcNow
            },
            new WalletUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Bob",
                LastName = "Brown",
                Email = "bob.brown@example.com",
                Address = "101 Pine St",
                PhoneNumber = "456-789-0123",
                DateOfBirth = DateTime.UtcNow
            },
            new WalletUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Charlie",
                LastName = "Davis",
                Email = "charlie.davis@example.com",
                Address = "202 Maple St",
                PhoneNumber = "567-890-1234",
                DateOfBirth = DateTime.UtcNow
            },
            new WalletUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Diana",
                LastName = "Miller",
                Email = "diana.miller@example.com",
                Address = "303 Birch St",
                PhoneNumber = "678-901-2345",
                DateOfBirth = DateTime.UtcNow
            },
            new WalletUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Eve",
                LastName = "Wilson",
                Email = "eve.wilson@example.com",
                Address = "404 Cedar St",
                PhoneNumber = "789-012-3456",
                DateOfBirth = DateTime.UtcNow
            },
            new WalletUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Frank",
                LastName = "Moore",
                Email = "frank.moore@example.com",
                Address = "505 Walnut St",
                PhoneNumber = "890-123-4567",
                DateOfBirth = DateTime.UtcNow
            },
            new WalletUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Grace",
                LastName = "Taylor",
                Email = "grace.taylor@example.com",
                Address = "606 Chestnut St",
                PhoneNumber = "901-234-5678",
                DateOfBirth = DateTime.UtcNow
            },
            new WalletUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Hank",
                LastName = "Anderson",
                Email = "hank.anderson@example.com",
                Address = "707 Spruce St",
                PhoneNumber = "012-345-6789",
                DateOfBirth = DateTime.UtcNow
            }
        );
    }
}