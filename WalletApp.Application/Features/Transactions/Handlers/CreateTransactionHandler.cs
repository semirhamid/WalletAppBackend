using AutoMapper;
using FluentValidation;
using MediatR;
using WalletApp.Application.DTOs.TransactionDTOs;
using WalletApp.Application.Features.Transactions.Commands;
using WalletApp.Application.Contracts.Persistence;
using WalletApp.Application.Exceptions;
using WalletApp.Domain.Entities;
using ValidationException = FluentValidation.ValidationException;

namespace WalletApp.Application.Features.Transactions.Handlers;

public class CreateTransactionHandler : IRequestHandler<CreateTransactionCommand, TransactionResponseDto>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IWalletUserRepository _walletUserRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateTransactionDto> _validator;
    private readonly IWalletRepository _walletRepository;

    public CreateTransactionHandler(ITransactionRepository transactionRepository, IMapper mapper, IValidator<CreateTransactionDto> validator, IWalletUserRepository walletUserRepository, IWalletRepository walletRepository)
    {
        _transactionRepository = transactionRepository;
        _mapper = mapper;
        _validator = validator;
        _walletUserRepository = walletUserRepository;
        _walletRepository = walletRepository;
    }

    public async Task<TransactionResponseDto> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request.Transation, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var user = await _walletUserRepository.GetByIdAsync(request.Transation.WalletUserId, cancellationToken);
        if (user == null)
        {
            throw new NotFoundException("User", request.Transation.WalletUserId);
        }

        var wallet = await _walletRepository.GetByWalletUserIdAsync(user.Id, cancellationToken);
        if (wallet == null)
        {
            throw new NotFoundException("Wallet", wallet);
        }
        var transaction = _mapper.Map<Transaction>(request.Transation);

        var canProceedTransaction = _walletRepository.CanProcessTransaction(wallet, transaction);
        if (!canProceedTransaction)
        {
            throw new InvalidOperationException("Transaction cannot be processed.");
        }
        transaction.WalletUser = user;

        await _transactionRepository.AddAsync(transaction, cancellationToken);
        return _mapper.Map<TransactionResponseDto>(transaction);
    }
}