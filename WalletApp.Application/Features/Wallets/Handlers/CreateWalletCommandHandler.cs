using AutoMapper;
using MediatR;
using WalletApp.Application.DTOs.WalletDto;
using WalletApp.Application.Features.Wallets.Commands;
using WalletApp.Application.Persistence.Contract;
using WalletApp.Domain.Entities;

namespace WalletApp.Application.Features.Wallets.Handlers;

public class CreateWalletCommandHandler : IRequestHandler<CreateWalletCommand, WalletResponseDto>
{
    private readonly IWalletRepository _walletRepository;
    private readonly IMapper _mapper;

    public CreateWalletCommandHandler(IWalletRepository walletRepository, IMapper mapper)
    {
        _walletRepository = walletRepository;
        _mapper = mapper;
    }

    public async Task<WalletResponseDto> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
    {
        var wallet = _mapper.Map<Wallet>(request.Driver);

        await _walletRepository.AddAsync(wallet, cancellationToken);
        return _mapper.Map<WalletResponseDto>(wallet);
    }
}