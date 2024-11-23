using MediatR;
using Microsoft.AspNetCore.Mvc;
using WalletApp.Application.DTOs.PointDto;
using WalletApp.Application.Features.Points.Commands;
using WalletApp.Application.Features.Points.Queries;

namespace WalletApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PointController : ControllerBase
    {
        private readonly ILogger<PointController> _logger;
        private readonly IMediator _mediator;

        public PointController(ILogger<PointController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        
        
        [HttpGet("User/{userId}", Name = "GetLatestPointByUserId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLatestPointByUserId(Guid userId)
        {
            try
            {
                var point = await _mediator.Send(new GetPointsByUserIdQuery(){ UserId = userId });
                if (point == null)
                {
                    return NotFound();
                }
                return Ok(point);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error occurred while getting point for user with id {userId}");
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}", Name = "GetPointById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var point = await _mediator.Send(new GetPointByIdQuery() { Id = id });
                if (point == null)
                {
                    return NotFound();
                }
                return Ok(point);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error occurred while getting point by id {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost(Name = "CreatePoint")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreatePointDto pointDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var command = new CreatePointCommand(pointDto);

                var pointId = await _mediator.Send(command);
                return CreatedAtRoute("GetPointById", new { id = pointId }, pointDto);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occurred while creating point");
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut("{id}", Name = "UpdatePoint")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePointDto updatePointDto)
        {
            try
            {
                if (id != updatePointDto.Id)
                {
                    return BadRequest("Point ID mismatch");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var command = new UpdatePointCommand(updatePointDto);

                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error occurred while updating point with id {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id}", Name = "DeletePoint")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _mediator.Send(new DeletePointCommand() { Id = id });
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error occurred while deleting point with id {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}