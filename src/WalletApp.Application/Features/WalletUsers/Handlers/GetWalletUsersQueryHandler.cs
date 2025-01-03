﻿using AutoMapper;
using MediatR;
using WalletApp.Application.DTOs.UserDto;
using WalletApp.Application.Features.WalletUser.Queries;
using WalletApp.Application.Contracts.Persistence;
namespace WalletApp.Application.Features.WalletUser.Handlers;

public class GetWalletUsersQueryHandler : IRequestHandler<GetWalletUsersQuery, List<WalletUserResponseDto>>
{
    private readonly IWalletUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetWalletUsersQueryHandler(IWalletUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<WalletUserResponseDto>> Handle(GetWalletUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<WalletUserResponseDto>>(users);
    }
}