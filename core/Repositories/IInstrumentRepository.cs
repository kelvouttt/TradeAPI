using Models.Domain.InstrumentAPI;

namespace Repositories.InstrumentAPIInterface;

public interface IInstrumentRepository
{
    IEnumerable<Instrument> GetAll();
    Instrument? GetInstrument(Guid id);
    void Add(Instrument instrument);
    void Delete(Instrument instrument);
}