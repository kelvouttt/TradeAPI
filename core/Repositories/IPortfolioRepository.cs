using PortfolioApi.Models;

interface IPortfolioRepository
{
    IEnumerable<Portfolio> GetAll();
    Portfolio? GetPortfolio(Guid id);
    void Add(Portfolio portfolio);
    void Delete(Portfolio portfolio);
}