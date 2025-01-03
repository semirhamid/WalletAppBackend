﻿using MediatR;
using WalletApp.Application.DTOs.UserDto;

namespace WalletApp.Application.Features.WalletUser.Queries;

public class GetWalletUserByIdQuery : IRequest<WalletUserResponseDto>
{
    public Guid Id { get; set; }
}