using ContactBook.Models;

namespace ContactBook.Interfaces;

public interface IContactService
{
    Contact Add(Contact contact);
    Contact GetById(int id);
    Contact Update(int id, Contact contact);
    bool Delete(int id);
    List<Contact> GetAll();
}
