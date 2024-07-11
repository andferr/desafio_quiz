using Domain.Common;

namespace Domain.Interfaces;

public interface IBaseRepository<T> where T : BaseEntity
{
    void Create(T entity, CancellationToken cancellationToken);
    void Update(T entity, CancellationToken cancellationToken);
    void Delete(T entity, CancellationToken cancellationToken);
    Task<T> Get(int id, CancellationToken cancellationToken);
    Task<List<T>> GetAll(CancellationToken cancellationToken);
}
