using DataAccess.GenericRepository;
using Domain.Entities;

namespace DataAccess.UserRepository;

public interface IUserRepository : IGenericRepository<User>
{
    public Task<bool> Authenticate(User user);
}