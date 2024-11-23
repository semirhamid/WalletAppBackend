using AutoMapper;
using MediatR;
using WalletApp.Application.DTOs.WalletDto;
using WalletApp.Application.Features.Wallets.Queries;
using WalletApp.Application.Persistence.Contract;

namespace WalletApp.Application.Features.Wallets.Handlers;

public class GetWalletByWalletUserIdQueryHandler : IRequestHandler<GetWalletByWalletUserIdQuery, WalletResponseDto>
{
    private readonly IWalletRepository _walletRepository;
    private readonly IMapper _mapper;

    public GetWalletByWalletUserIdQueryHandler(IWalletRepository walletRepository, IMapper mapper)
    {
        _walletRepository = walletRepository;
        _mapper = mapper;
    }

    public async Task<WalletResponseDto> Handle(GetWalletByWalletUserIdQuery request, CancellationToken cancellationToken)
    {
        var wallet = await _walletRepository.GetByWalletUserIdAsync(request.WalletUserId, cancellationToken);
        if (wallet == null)
        {
            throw new ApplicationException($"Wallet for user with id {request.WalletUserId} not found");
        }

        return _mapper.Map<WalletResponseDto>(wallet);
    }
}