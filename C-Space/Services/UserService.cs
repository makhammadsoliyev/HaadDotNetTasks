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
        User existUser = users.FirstOrDefault(user => user.Phone == user.Phone);
        if (existUser is not null)
            throw new Exception("This user already exists");

        users.Add(user);

        return user;
    }

    public bool Delete(int id)
    {
        User user = users.FirstOrDefault(user => user.Id == id);
        if (user is null)
            throw new Exception("This user was not found");

        return users.Remove(user);
    }

    public List<User> GetAll()
        => users;

    public User GetById(int id)
    {
        User user = users.FirstOrDefault(user => user.Id == id);
        if (user == null)
            throw new Exception("This user was not found");

        return user;
    }

    public User Update(int id, User user)
    {
        User existUser = users.FirstOrDefault(user => user.Id == id);
        if (existUser is null)
            throw new Exception("This user was not found");

        existUser.Id = id;
        existUser.Email = user.Email;
        existUser.Phone = user.Phone;
        existUser.LastName = user.LastName;
        existUser.FirstName = user.FirstName;

        return existUser;
    }
}
