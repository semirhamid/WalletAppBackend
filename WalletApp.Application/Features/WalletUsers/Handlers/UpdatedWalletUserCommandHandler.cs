using AutoMapper;
using FluentValidation;
using MediatR;
using WalletApp.Application.DTOs.UserDto;
using WalletApp.Application.Features.WalletUser.Commands;
using WalletApp.Application.Contracts.Persistence;


namespace WalletApp.Application.Features.WalletUser.Handlers;

public class UpdatedWalletUserCommandHandler : IRequestHandler<UpdateWalletUserCommand, WalletUserResponseDto>
{
    private readonly IWalletUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateWalletUserDto> _validator;

    public UpdatedWalletUserCommandHandler(IWalletUserRepository userRepository, IMapper mapper, IValidator<UpdateWalletUserDto> validator)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<WalletUserResponseDto> Handle(UpdateWalletUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request.WalletUser, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        var user = await _userRepository.GetByIdAsync(request.WalletUser.Id, cancellationToken);
        if (user == null)
        {
            throw new ApplicationException($"User with id {request.WalletUser.Id} not found");
        }
        
        await _userRepository.UpdateAsync(_mapper.Map<Domain.Entities.WalletUser>(request.WalletUser), cancellationToken);
        return _mapper.Map<WalletUserResponseDto>(user);
    }
}