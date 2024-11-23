using AutoMapper;
using FluentValidation;
using MediatR;
using WalletApp.Application.DTOs.WalletDto;
using WalletApp.Application.Features.Wallets.Commands;
using WalletApp.Application.Persistence.Contract;
using WalletApp.Domain.Entities;
using ValidationException = WalletApp.Application.Exceptions.ValidationException;

public class CreateWalletCommandHandler : IRequestHandler<CreateWalletCommand, WalletResponseDto>
{
    private readonly IWalletRepository _walletRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateWalletDto> _validator;

    public CreateWalletCommandHandler(IWalletRepository walletRepository, IMapper mapper, IValidator<CreateWalletDto> validator)
    {
        _walletRepository = walletRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<WalletResponseDto> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request.Driver, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var wallet = _mapper.Map<Wallet>(request.Driver);
        await _walletRepository.AddAsync(wallet, cancellationToken);
        return _mapper.Map<WalletResponseDto>(wallet);
    }
}