using Domain.Entities;

namespace Domain.Interfaces;

public interface IUserRepository : IBaseRepository<Users>
{
    Task<Users> GetByEmail(string username, CancellationToken cancellationToken);
}
