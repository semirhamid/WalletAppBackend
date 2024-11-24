using MediatR;
using WalletApp.Application.DTOs.PointDto;

namespace WalletApp.Application.Features.Points.Commands;

public class CreatePointCommand : IRequest<PointResponseDto>
{
    public CreatePointDto Point { get; set; }

    public CreatePointCommand(CreatePointDto pointDto)
    {
        Point = pointDto;
    }
}