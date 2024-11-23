using MediatR;
using WalletApp.Application.DTOs.PointDto;

namespace WalletApp.Application.Features.Points.Commands;

public class UpdatePointCommand : IRequest<PointResponseDto>
{
    public UpdatePointDto Point { get; set; }

    public UpdatePointCommand(UpdatePointDto pointDto)
    {
        Point = pointDto;
    }
}