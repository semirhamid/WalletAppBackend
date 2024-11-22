using AutoMapper;
using MediatR;
using WalletApp.Application.DTOs.UserDto;
using WalletApp.Application.Features.WalletUser.Commands;
using WalletApp.Application.Persistence.Contract;

namespace WalletApp.Application.Features.WalletUser.Handlers;
public class CreateWalletUserCommandHandler : IRequestHandler<CreateWalletUserCommand, WalletUserDto>
{
    private readonly IWalletUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateWalletUserCommandHandler(IWalletUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<WalletUserDto> Handle(CreateWalletUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<Domain.Entities.WalletUser>(request);
        var createdUser = await _userRepository.AddAsync(user, cancellationToken);
        return _mapper.Map<WalletUserDto>(createdUser);
    }
}