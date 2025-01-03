﻿using WalletApp.Application.DTOs.Common;

namespace WalletApp.Application.DTOs.TransactionDTOs;

public class TransactionResponseDto : BaseDTO
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Type { get; set; } = string.Empty;
    public bool IsPending { get; set; }
    public Guid WalletUserId { get; set; }
}

public class UpdateTransationDto : TransactionResponseDto
{
    
}

public class CreateTransactionDto 
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public bool IsPending { get; set; }
    public Guid WalletUserId { get; set; }
}