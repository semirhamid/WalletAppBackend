using MediatR;
using WalletApp.Application.DTOs.WalletDto;

namespace WalletApp.Application.Features.Wallets.Commands;

public class UpdateWalletCommand : IRequest<WalletResponseDto>
{
    public UpdateWalletDto Driver { get; set; }
    
    public UpdateWalletCommand(UpdateWalletDto driver)
    {
        Driver = driver;
    }
}