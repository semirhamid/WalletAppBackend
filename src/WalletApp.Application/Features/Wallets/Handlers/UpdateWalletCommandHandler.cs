using AutoMapper;
using FluentValidation;
using MediatR;
using WalletApp.Application.DTOs.WalletDto;
using WalletApp.Application.Features.Wallets.Commands;
using WalletApp.Application.Contracts.Persistence;
using WalletApp.Domain.Entities;
using ValidationException = WalletApp.Application.Exceptions.ValidationException;

namespace WalletApp.Application.Features.Wallets.Handlers;

public class UpdateWalletCommandHandler : IRequestHandler<UpdateWalletCommand, WalletResponseDto>
{
    private readonly IWalletRepository _walletRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateWalletDto> _validator;

    public UpdateWalletCommandHandler(IWalletRepository walletRepository, IMapper mapper, IValidator<UpdateWalletDto> validator)
    {
        _walletRepository = walletRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<WalletResponseDto> Handle(UpdateWalletCommand request, CancellationToken cancellationToken)
    {
        // Validate the DTO
        var validationResult = await _validator.ValidateAsync(request.Driver, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        // Retrieve the wallet entity
        var wallet = await _walletRepository.GetByIdAsync(request.Driver.Id, cancellationToken);
        if (wallet == null)
        {
            throw new ApplicationException($"Wallet with id {request.Driver.Id} not found");
        }

        // Map the updated properties to the existing entity
        _mapper.Map(request.Driver, wallet);

        // Save the updated entity
        await _walletRepository.UpdateAsync(wallet, cancellationToken);

        // Map the entity back to a response DTO
        return _mapper.Map<WalletResponseDto>(wallet);
    }

}