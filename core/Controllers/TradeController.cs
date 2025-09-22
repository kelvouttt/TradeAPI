using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TradeApi.Models;
using TradeApi.Mappings;
using TradeInterfaceApi.Data;
using Microsoft.EntityFrameworkCore;
using TradeRepositoryInterface;
using TradeApi.Repository;

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
        // var tradeDtos = trades.Select(trade => trade.ToDto()).ToList();

        return Ok(trades);
    }

    [HttpGet("{id}")]
    public IActionResult GetTrade(Guid id)
    {
        var trade = _repo.GetTrade(id);
        return Ok(trade);
    }
}