using ContactBook.Interfaces;
using ContactBook.Models;

namespace ContactBook.Services;

public class GroupService : IGroupService
{
    private readonly List<Group> groups;
    private readonly ContactService contactService;

    public GroupService(ContactService contactService)
    {
        this.groups = new List<Group>();
        this.contactService = contactService;
    }

    public Group Create(Group group)
    {
        groups.Add(group);
        return group;
    }

    public bool Delete(int id)
    {
        var group = groups.FirstOrDefault(g => g.Id == id)
            ?? throw new Exception("Group with this id was not found...");

        return groups.Remove(group);
    }

    public List<Group> GetAll()
        => groups;

    public Group GetById(int id)
    {
        var group = groups.FirstOrDefault(g => g.Id == id)
            ?? throw new Exception("Group with this id was not found...");

        return group;
    }

    public Group Update(int id, Group group)
    {
        var existGroup = groups.FirstOrDefault(g => g.Id == id)
            ?? throw new Exception("Group with this id was not found...");

        existGroup.Id = id;
        existGroup.Name = group.Name;
        existGroup.Description = group.Description;

        return existGroup;
    }

    public Group AddContact(int groupId, int contactId)
    {
        var group = groups.FirstOrDefault(g => g.Id == groupId)
            ?? throw new Exception("Group with this id was not found...");
        var contact = contactService.GetById(contactId);

        group.Contacts.Add(contact);
        return group;
    }

    public bool DeleteContact(int groupId, int contactId)
    {
        var group = groups.FirstOrDefault(g => g.Id == groupId)
            ?? throw new Exception("Group with this id was not found...");
        var contact = group.Contacts.FirstOrDefault(g => g.Id == contactId)
            ?? throw new Exception("Contact with this id was not found...");

        return group.Contacts.Remove(contact);
    }

    public List<Contact> GetContactsByGroup(int id)
    {
        var group = groups.FirstOrDefault(g => g.Id == id)
            ?? throw new Exception("Group with this id was not found...");

        return group.Contacts;
    }
}
