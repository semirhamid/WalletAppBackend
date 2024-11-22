using MediatR;
using WalletApp.Application.DTOs.UserDto;

namespace WalletApp.Application.Features.WalletUser.Commands;

public class CreateWalletUserCommand : IRequest<WalletUserDto>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
}