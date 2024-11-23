using MediatR;
using WalletApp.Application.DTOs.UserDto;

namespace WalletApp.Application.Features.WalletUser.Commands;

public class UpdateWalletUserCommand : IRequest<WalletUserResponseDto>
{
   public UpdateWalletUserDto WalletUser { get; set; }

   public UpdateWalletUserCommand(UpdateWalletUserDto updateWalletUserDto)
   {
      WalletUser = updateWalletUserDto;

   }
}