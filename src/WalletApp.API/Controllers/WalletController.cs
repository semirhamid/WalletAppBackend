using MediatR;
using Microsoft.AspNetCore.Mvc;
using WalletApp.Application.DTOs.WalletDto;
using WalletApp.Application.Features.Wallets.Commands;
using WalletApp.Application.Features.Wallets.Queries;
using WalletApp.Application.Features.WalletUser.Queries;


namespace WalletApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WalletController : ControllerBase
    {
        private readonly ILogger<WalletController> _logger;
        private readonly IMediator _mediator;

        public WalletController(ILogger<WalletController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        [HttpGet(Name = "GetAllWallets")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var wallets = await _mediator.Send(new GetWalletQuery());
                return Ok(wallets);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occurred while getting all wallets");
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpGet("{id}", Name = "GetWalletById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var wallet = await _mediator.Send(new GetWalletByIdQuery { Id = id });
                if (wallet == null)
                {
                    return NotFound();
                }
                return Ok(wallet);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error occurred while getting wallet by id {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("User/{id}", Name = "GetWalletByUserId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByUserId(Guid id)
        {
            try
            {
                var wallet = await _mediator.Send(new GetWalletByWalletUserIdQuery{ WalletUserId = id });
                if (wallet == null)
                {
                    return NotFound();
                }
                return Ok(wallet);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error occurred while getting wallet by id {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost(Name = "CreateWallet")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateWalletDto walletDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var command = new CreateWalletCommand(walletDto);

                var walletId = await _mediator.Send(command);
                return CreatedAtRoute("GetWalletById", new { id = walletId }, command);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occurred while creating wallet");
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut("{id}", Name = "UpdateWallet")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateWalletDto updateWalletDto)
        {
            try
            {
                if (id != updateWalletDto.Id)
                {
                    return BadRequest("Wallet ID mismatch");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var command = new UpdateWalletCommand(updateWalletDto);

                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error occurred while updating wallet with id {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id}", Name = "DeleteWallet")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteWalletCommand { Id = id });
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error occurred while deleting wallet with id {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}