using C_Space.Models;

namespace C_Space.Interfaces;

public interface IUserService
{
    User Create(User user);
    User Update(int id, User user);
    bool Delete(int id);
    User GetById(int id);
    List<User> GetAll();
}
