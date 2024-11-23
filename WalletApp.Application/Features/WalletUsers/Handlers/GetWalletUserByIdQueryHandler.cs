using AutoMapper;
using MediatR;
using WalletApp.Application.DTOs.UserDto;
using WalletApp.Application.Features.WalletUser.Queries;
using WalletApp.Application.Persistence.Contract;

namespace WalletApp.Application.Features.WalletUser.Handlers;

public class GetWalletUserByIdQueryHandler : IRequestHandler<GetWalletUserByIdQuery, WalletUserResponseDto>
{
    private readonly IWalletUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetWalletUserByIdQueryHandler(IWalletUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<WalletUserResponseDto> Handle(GetWalletUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
        if (user == null)
        {
            throw new ApplicationException($"User with id {request.Id} not found");
        }

        return _mapper.Map<WalletUserResponseDto>(user);
    }
}