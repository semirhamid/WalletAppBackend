using AutoMapper;
using MediatR;
using WalletApp.Application.DTOs.WalletDto;
using WalletApp.Application.Features.Wallets.Queries;
using WalletApp.Application.Contracts.Persistence;

namespace WalletApp.Application.Features.Wallets.Handlers;

public class GetWalletQueryHandler : IRequestHandler<GetWalletQuery, List<WalletResponseDto>>
{
    private readonly IWalletRepository _walletRepository;
    private readonly IMapper _mapper;

    public GetWalletQueryHandler(IWalletRepository walletRepository, IMapper mapper)
    {
        _walletRepository = walletRepository;
        _mapper = mapper;
    }

    public async Task<List<WalletResponseDto>> Handle(GetWalletQuery request, CancellationToken cancellationToken)
    {
        var wallet = await _walletRepository.GetAllAsync(cancellationToken);
        if (wallet == null)
        {
            throw new ApplicationException("No Wallet found");
        }

        return _mapper.Map<List<WalletResponseDto>>(wallet);
    }
}