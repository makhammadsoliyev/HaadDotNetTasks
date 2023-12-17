using C_Space.Interfaces;
using C_Space.Models;

namespace C_Space.Services;

public class UserService : IUserService
{
    private List<User> users;
    public UserService()
    {
        this.users = new List<User>();
    }
    public User Create(User user)
    {
        users.Add(user);
        return user;
    }

    public bool Delete(int id)
    {
        return users.Remove(users.FirstOrDefault(user => user.Id == id));
    }

    public List<User> GetAll()
        => users;

    public User GetById(int id)
    {
        return users.FirstOrDefault(user => user.Id == id);
    }

    public User Update(int id, User user)
    {
        User existUser = users.FirstOrDefault(user => user.Id == id);
        if (existUser is not null)
        {
            existUser.Id = id;
            existUser.Email = user.Email;
            existUser.Phone = user.Phone;
            existUser.LastName = user.LastName;
            existUser.FirstName = user.FirstName;
        }
        return existUser;
    }
}
