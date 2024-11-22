using AutoMapper;
using MediatR;
using WalletApp.Application.DTOs.WalletDto;
using WalletApp.Application.Features.Wallets.Queries;
using WalletApp.Application.Persistence.Contract;

namespace WalletApp.Application.Features.Wallets.Handlers;

public class GetWalletByWalletUserIdQueryHandler : IRequestHandler<GetWalletByWalletUserIdQuery, WalletDto>
{
    private readonly IWalletRepository _walletRepository;
    private readonly IMapper _mapper;

    public GetWalletByWalletUserIdQueryHandler(IWalletRepository walletRepository, IMapper mapper)
    {
        _walletRepository = walletRepository;
        _mapper = mapper;
    }

    public async Task<WalletDto> Handle(GetWalletByWalletUserIdQuery request, CancellationToken cancellationToken)
    {
        var wallet = await _walletRepository.GetByWalletUserIdAsync(request.WalletUserId, cancellationToken);
        if (wallet == null)
        {
            throw new ApplicationException($"Wallet for user with id {request.WalletUserId} not found");
        }

        return _mapper.Map<WalletDto>(wallet);
    }
}