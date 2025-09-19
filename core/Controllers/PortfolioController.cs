using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Mappings;
using PortfolioApi.Models;
using TradeInterfaceApi.Data;

namespace PortfolioApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PortfolioController : ControllerBase
{
    private readonly TradeDbContext _context;

    public PortfolioController(TradeDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult CreatePortfolio([FromBody] Portfolio portfolio)
    {
        portfolio.Id = Guid.NewGuid();
        portfolio.PortfolioCreation = DateTime.UtcNow;

        _context.Portfolios.Add(portfolio);
        _context.SaveChanges();

        return Ok(portfolio.ToDto());
    }

    [HttpGet("{id}")]
    public IActionResult GetPortfolioById(Guid id)
    {
        var portfolio = _context.Portfolios.FirstOrDefault(p => p.Id == id);
        if (portfolio == null)
            return NotFound();

        return Ok(portfolio);
    }

    [HttpGet]
    public IActionResult GetAllPortfolios()
    {
        var portfolios = _context.Portfolios
            .Include(p => p.Trades)
            .ToList();
        var portfolioDtos = portfolios.Select(p => p.ToDto()).ToList();
        return Ok(portfolioDtos);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePortfolio(Guid id)
    {
        try
        {
            var portfolio = _context.Portfolios.FirstOrDefault(p => p.Id == id);
            if (portfolio == null)
            {
                return NotFound($"Portfolio {portfolio?.PortfolioName} not found!");
            }

            _context.Portfolios.Remove(portfolio);
            _context.SaveChanges();

            return StatusCode(StatusCodes.Status204NoContent, "Portfolio has been removed!");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting portfolio.");
        }
    }
}