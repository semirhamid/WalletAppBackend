using AutoMapper;
using MediatR;
using WalletApp.Application.DTOs.WalletDto;
using WalletApp.Application.Features.Wallets.Commands;
using WalletApp.Application.Persistence.Contract;
using WalletApp.Domain.Entities;

namespace WalletApp.Application.Features.Wallets.Handlers;

public class UpdateWalletCommandHandler : IRequestHandler<UpdateWalletCommand, WalletResponseDto>
{
    private readonly IWalletRepository _walletRepository;
    private readonly IMapper _mapper;

    public UpdateWalletCommandHandler(IWalletRepository walletRepository, IMapper mapper)
    {
        _walletRepository = walletRepository;
        _mapper = mapper;
    }

    public async Task<WalletResponseDto> Handle(UpdateWalletCommand request, CancellationToken cancellationToken)
    {
        var wallet = await _walletRepository.GetByIdAsync(request.Driver.Id, cancellationToken);
        if (wallet == null)
        {
            throw new ApplicationException($"Wallet with id {request.Driver.Id} not found");
        }
        await _walletRepository.UpdateAsync(_mapper.Map<Wallet>(request.Driver), cancellationToken);
        return _mapper.Map<WalletResponseDto>(wallet);
    }
}