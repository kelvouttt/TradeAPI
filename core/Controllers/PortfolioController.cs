using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Mappings;
using PortfolioRepositoryInterface;
using PortfolioApi.Models;


namespace PortfolioApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PortfolioController : ControllerBase
{
    private readonly IPortfolioRepository _repo;

    public PortfolioController(IPortfolioRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public IActionResult GetAllPortfolios()
    {
        var portfolios = _repo.GetAll();
        var dtoResult = portfolios.Select(p => p.ToDto()).ToList();

        return Ok(dtoResult);
    }

    [HttpGet("{id}")]
    public IActionResult GetPortfolio(Guid id)
    {
        var portfolio = _repo.GetPortfolio(id);
        if (portfolio == null)
            return NotFound();

        return Ok(portfolio.ToDto());
    }

    [HttpPost]
    public IActionResult CreatePortfolio(Portfolio portfolio)
    {
        portfolio.Id = Guid.NewGuid();
        portfolio.PortfolioCreation = DateTime.UtcNow;
        _repo.Add(portfolio);

        return Ok(portfolio);
    }

    [HttpDelete("{id}")]
    public IActionResult RemovePortfolio(Guid id)
    {
        try
        {
            var portfolio = _repo.GetPortfolio(id);
            if (portfolio == null)
            {
                return NotFound();
            }

            _repo.Delete(portfolio);

            return StatusCode(StatusCodes.Status204NoContent);
        }
        catch (Exception)
        {
            return NotFound();
        }
    }
}