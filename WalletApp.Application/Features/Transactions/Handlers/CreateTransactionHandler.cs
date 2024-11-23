using AutoMapper;
using FluentValidation;
using MediatR;
using WalletApp.Application.DTOs.TransactionDTOs;
using WalletApp.Application.Features.Transactions.Commands;
using WalletApp.Application.Contracts.Persistence;
using WalletApp.Domain.Entities;

namespace WalletApp.Application.Features.Transactions.Handlers;

public class CreateTransactionHandler : IRequestHandler<CreateTransactionCommand, TransactionResponseDto>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateTransactionDto> _validator;

    public CreateTransactionHandler(ITransactionRepository transactionRepository, IMapper mapper, IValidator<CreateTransactionDto> validator)
    {
        _transactionRepository = transactionRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<TransactionResponseDto> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request.Transation, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        var transaction = _mapper.Map<Transaction>(request);

        await _transactionRepository.AddAsync(transaction, cancellationToken);
        return _mapper.Map<TransactionResponseDto>(transaction);
    }
}