using Microsoft.EntityFrameworkCore;
using MoveIT.Data.Entities;
using MoveIT.Data.Persistence.Repositories.Interfaces;

namespace MoveIT.Data.Persistence.Repositories;

public class ProposalRepository : BaseRepository, IProposalRepository
{
    public ProposalRepository(MoveItDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Proposal>> GetAllAsync() =>
        await DbContext.Proposals.ToListAsync();

    public async Task<Proposal> GetByIdAsync(int id) =>
        await DbContext.Proposals.FirstOrDefaultAsync(p => p.Id == id);

    public async Task<IEnumerable<Proposal>> GetByUserIdAsync(string userId) =>
        await DbContext.Proposals.Where(p => p.UserId == userId).ToListAsync();

    public async Task Save(Proposal entity)
    {
        DbContext.Add(entity);
        await DbContext.SaveChangesAsync();
    }

    public async Task Update(Proposal entity)
    {
        DbContext.Update(entity);
        await DbContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var proposal = await GetByIdAsync(id);

        if (proposal != null)
            DbContext.Proposals.Remove(proposal);

        await DbContext.SaveChangesAsync();
    }

}