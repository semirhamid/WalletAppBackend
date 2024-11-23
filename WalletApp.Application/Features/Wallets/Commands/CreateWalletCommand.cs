using MediatR;
using WalletApp.Application.DTOs.WalletDto;

namespace WalletApp.Application.Features.Wallets.Commands;

public class CreateWalletCommand : IRequest<WalletResponseDto>
{
    public CreateWalletDto Driver { get; set; }
    
    public CreateWalletCommand(CreateWalletDto driver)
    {
        Driver = driver;
    }
}