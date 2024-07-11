using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

public class UserRepository : BaseRepository<Users>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {}

    public async Task<Users> GetByEmail(string username, CancellationToken cancellationToken)
    {
        return await Context.Users.FirstOrDefaultAsync(x => x.Username == username, cancellationToken);
    }
}
