using AutoMapper;
using MediatR;
using WalletApp.Application.DTOs.WalletDto;
using WalletApp.Application.Features.Wallets.Commands;
using WalletApp.Application.Persistence.Contract;
using WalletApp.Domain.Entities;

namespace WalletApp.Application.Features.Wallets.Handlers;

public class UpdateWalletCommandHandler : IRequestHandler<UpdateWalletCommand, WalletDto>
{
    private readonly IWalletRepository _walletRepository;
    private readonly IMapper _mapper;

    public UpdateWalletCommandHandler(IWalletRepository walletRepository, IMapper mapper)
    {
        _walletRepository = walletRepository;
        _mapper = mapper;
    }

    public async Task<WalletDto> Handle(UpdateWalletCommand request, CancellationToken cancellationToken)
    {
        var wallet = await _walletRepository.GetByIdAsync(request.Id, cancellationToken);
        if (wallet == null)
        {
            throw new ApplicationException($"Wallet with id {request.Id} not found");
        }
        await _walletRepository.UpdateAsync(wallet, cancellationToken);
        return _mapper.Map<WalletDto>(wallet);
    }
}