using MoveIT.Data.Entities;

namespace MoveIT.Data.Persistence.Repositories.Interfaces;

public interface IProposalRepository
{
    Task<IEnumerable<Proposal>> GetAllAsync();
    Task<Proposal> GetByIdAsync(int id);
    Task<IEnumerable<Proposal>> GetByUserIdAsync(string userId);
    Task Save(Proposal proposal);
    Task Update(Proposal proposal);
    Task Delete(int id);
}