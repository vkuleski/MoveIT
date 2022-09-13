using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace MoveIT.Data.Persistence.Repositories;

public abstract class BaseRepository
{
    protected MoveItDbContext DbContext { get; }

    protected BaseRepository(MoveItDbContext dbContext)
    {
        DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }
}

