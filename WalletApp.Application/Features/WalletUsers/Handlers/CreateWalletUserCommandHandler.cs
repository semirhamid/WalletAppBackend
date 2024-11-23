using AutoMapper;
using FluentValidation;
using MediatR;
using WalletApp.Application.DTOs.UserDto;
using WalletApp.Application.Features.WalletUser.Commands;
using WalletApp.Application.Contracts.Persistence;
using ValidationException = WalletApp.Application.Exceptions.ValidationException;

namespace WalletApp.Application.Features.WalletUser.Handlers;
public class CreateWalletUserCommandHandler : IRequestHandler<CreateWalletUserCommand, WalletUserResponseDto>
{
    private readonly IWalletUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateWalletUserDto> _validator;

    public CreateWalletUserCommandHandler(IWalletUserRepository userRepository, IMapper mapper, IValidator<CreateWalletUserDto> validator)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<WalletUserResponseDto> Handle(CreateWalletUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request.WalletUser, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        var user = _mapper.Map<Domain.Entities.WalletUser>(request);
        var createdUser = await _userRepository.AddAsync(user, cancellationToken);
        return _mapper.Map<WalletUserResponseDto>(createdUser);
    }
}