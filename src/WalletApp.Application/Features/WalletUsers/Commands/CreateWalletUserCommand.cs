

using MediatR;
using WalletApp.Application.DTOs.UserDto;
using WalletApp.Application.DTOs.WalletDto;

namespace WalletApp.Application.Features.WalletUser.Commands;

public class CreateWalletUserCommand : IRequest<WalletUserResponseDto>
{
    public CreateWalletUserDto WalletUser { get; set; }

    public CreateWalletUserCommand(CreateWalletUserDto user)
    {
        WalletUser = user;
    }
}