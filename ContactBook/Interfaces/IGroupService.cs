using ContactBook.Models;

namespace ContactBook.Interfaces;

public interface IGroupService
{
    Group Create(Group group);
    Group GetById(int id);
    Group Update(int id, Group group);
    bool Delete(int id);
    List<Group> GetAll();
    Group AddContact(int groupId, int contactId);
    bool DeleteContact(int groupId, int contactId);
    List<Contact> GetContactsByGroup(int id);
}
