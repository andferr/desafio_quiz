using Domain.Common;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext Context;

    public BaseRepository(AppDbContext context)
    {
        Context = context;
    }

    public void Create(T entity, CancellationToken cancellationToken)
    {
        entity.CreatedAt = DateTimeOffset.UtcNow;
        Context.Add(entity);
        Context.SaveChanges();
    }

    public void Update(T entity, CancellationToken cancellationToken)
    {
        entity.UpdatedAt = DateTimeOffset.UtcNow;
        Context.Update(entity);
        Context.SaveChanges();
    }

    public void Delete(T entity, CancellationToken cancellationToken)
    {
        entity.UpdatedAt = DateTimeOffset.UtcNow;
        Context.Remove(entity);
        Context.SaveChanges();
    }

    public async Task<T> Get(int id, CancellationToken cancellationToken)
    {
        return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<List<T>> GetAll(CancellationToken cancellationToken)
    {
        return await Context.Set<T>().ToListAsync(cancellationToken);
    }
}
