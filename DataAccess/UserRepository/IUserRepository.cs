using DataAccess.GenericRepository;
using Domain.Entities;

namespace DataAccess.UserRepository;

public interface IUserRepository : IGenericRepository<User>
{
    public Task<User?> GetUserByEmail(string email);

    public Task<List<User>> GetUsersNotAttendingCourse(Guid id);
    public Task<List<User>> GetUsersNotAttendingSession(Guid id);
}