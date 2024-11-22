using MediatR;
using WalletApp.Application.DTOs.UserDto;

namespace WalletApp.Application.Features.WalletUser.Queries;

public class GetWalletUsersQuery : IRequest<List<WalletUserDto>>
{
}