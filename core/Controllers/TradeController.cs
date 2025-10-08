using Microsoft.AspNetCore.Mvc;
using Models.Domain.TradeAPI;
using Repositories.TradeAPIInterface;
using Mappings.TradeAPI;


namespace TradeInterfaceApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TradeController : ControllerBase
{
    private readonly ITradeRepository _repo;

    public TradeController(ITradeRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public IActionResult GetAllTrades()
    {
        var trades = _repo.GetAll();
        var dtoResult = trades.Select(t => t.ToDto()).ToList();

        return Ok(dtoResult);
    }

    [HttpGet("{id}")]
    public IActionResult GetTrade(Guid id)
    {
        var trade = _repo.GetTrade(id);
        if (trade == null)
        {
            return NotFound();
        }
        
        return Ok(trade.ToDto());
    }

    [HttpPost]
    public IActionResult CreateTrade(Trade trade)
    {
        _repo.Add(trade);

        return Ok(trade);
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveTrade(Guid id)
    {
        try
        {
            var trade = _repo.GetTrade(id);
            if (trade == null)
            {
                return NotFound();
            }

            _repo.Delete(trade);

            return StatusCode(StatusCodes.Status204NoContent);
        }
        catch (Exception)
        {
            return NotFound();
        }
    }
}