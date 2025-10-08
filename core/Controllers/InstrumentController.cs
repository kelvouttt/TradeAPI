using Models.Domain.InstrumentAPI;
using Microsoft.AspNetCore.Mvc;
using Repositories.InstrumentAPIInterface;
using Mappings.InstrumentAPI;

namespace InstrumentInterfaceApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InstrumentController : ControllerBase
{
    private readonly IInstrumentRepository _repo;

    public InstrumentController(IInstrumentRepository repo)
    {
        _repo = repo;
    }

    [HttpPost]
    public IActionResult CreateInstrument(Instrument instrument)
    {
        _repo.Add(instrument);

        return Ok(instrument);
    }

    [HttpGet]
    public IActionResult GetAllInstruments()
    {
        var instruments = _repo.GetAll();
        var dtoResult = instruments.Select(i => i.ToDto()).ToList();
        return Ok(dtoResult);
    }

    [HttpGet("{id}")]
    public IActionResult GetInstrument(Guid id)
    {
        var instrument = _repo.GetInstrument(id);
        if (instrument == null)
        {
            return NotFound();
        }

        return Ok(instrument.ToDto());
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveInstrument(Guid id)
    {
        try
        {
            var instrument = _repo.GetInstrument(id);
            if (instrument == null)
            {
                return NotFound();
            }

            _repo.Delete(instrument);

            return StatusCode(StatusCodes.Status204NoContent);
        }
        catch (Exception)
        {
            return NotFound();
        }
    }
}