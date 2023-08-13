using DataAccess.GenericRepository;
using Domain.Entities;

namespace DataAccess.UserRepository;

public interface IUserRepository : IGenericRepository<User>
{
    public Task<User?> GetUserByEmail(string email);
}