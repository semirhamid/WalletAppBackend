using AutoMapper;
using MediatR;
using WalletApp.Application.DTOs.WalletDto;
using WalletApp.Application.Features.Wallets.Queries;
using WalletApp.Application.Contracts.Persistence;

namespace WalletApp.Application.Features.Wallets.Handlers;

public class GetWalletByIdQueryHandler : IRequestHandler<GetWalletByIdQuery, WalletResponseDto>
{
    private readonly IWalletRepository _walletRepository;
    private readonly IMapper _mapper;

    public GetWalletByIdQueryHandler(IWalletRepository walletRepository, IMapper mapper)
    {
        _walletRepository = walletRepository;
        _mapper = mapper;
    }

    public async Task<WalletResponseDto> Handle(GetWalletByIdQuery request, CancellationToken cancellationToken)
    {
        var wallet = await _walletRepository.GetByIdAsync(request.Id, cancellationToken);
        if (wallet == null)
        {
            throw new ApplicationException($"Wallet with id {request.Id} not found");
        }

        return _mapper.Map<WalletResponseDto>(wallet);
    }
}