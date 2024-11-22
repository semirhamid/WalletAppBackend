using AutoMapper;
using MediatR;
using WalletApp.Application.DTOs.UserDto;
using WalletApp.Application.Features.WalletUser.Commands;
using WalletApp.Application.Persistence.Contract;


namespace WalletApp.Application.Features.WalletUser.Handlers;

public class UpdatedWalletUserCommandHandler : IRequestHandler<UpdateWalletUserCommand, WalletUserDto>
{
    private readonly IWalletUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdatedWalletUserCommandHandler(IWalletUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<WalletUserDto> Handle(UpdateWalletUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
        if (user == null)
        {
            throw new ApplicationException($"User with id {request.Id} not found");
        }

        _mapper.Map(request, user);
        await _userRepository.UpdateAsync(user, cancellationToken);
        return _mapper.Map<WalletUserDto>(user);
    }
}