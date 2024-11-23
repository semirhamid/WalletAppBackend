using MediatR;
using Microsoft.AspNetCore.Mvc;
using WalletApp.Application.DTOs.TransactionDTOs;
using WalletApp.Application.Features.Transactions.Commands;
using WalletApp.Application.Features.Transactions.Queries;

namespace WalletApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly IMediator _mediator;

        public TransactionController(ILogger<TransactionController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        
        
        [HttpGet( Name = "GetTransactions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTransactions()
        {
            try
            {
                var transactions = await _mediator.Send(new GetTransactionQuery());
                if (transactions == null)
                {
                    return NotFound();
                }
                return Ok(transactions);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occurred while getting transactions");
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        
        [HttpGet("User/{userId}", Name = "GetLatestTransactionByUserId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLatestTransactionByUserId(Guid userId)
        {
            try
            {
                var transaction = await _mediator.Send(new GetUserLatestTransactionQuery{ UserId = userId });
                if (transaction == null)
                {
                    return NotFound();
                }
                return Ok(transaction);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error occurred while getting transaction for user with id {userId}");
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}", Name = "GetTransactionById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var transaction = await _mediator.Send(new GetTransactionByIdQuery { Id = id });
                if (transaction == null)
                {
                    return NotFound();
                }
                return Ok(transaction);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error occurred while getting transaction by id {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost(Name = "CreateTransaction")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateTransactionDto transationDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var command = new CreateTransactionCommand(transationDto);

                var transactionId = await _mediator.Send(command);
                return CreatedAtRoute("GetTransactionById", new { id = transactionId }, transationDto);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occurred while creating transaction");
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut("{id}", Name = "UpdateTransaction")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTransationDto updateTransationDto)
        {
            try
            {
                if (id != updateTransationDto.Id)
                {
                    return BadRequest("Transaction ID mismatch");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var command = new UpdateTransactionCommand(updateTransationDto);

                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error occurred while updating transaction with id {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id}", Name = "DeleteTransaction")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteTransactionCommand { Id = id });
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error occurred while deleting transaction with id {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}