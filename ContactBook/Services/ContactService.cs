using ContactBook.Interfaces;
using ContactBook.Models;

namespace ContactBook.Services;

public class ContactService : IContactService
{
    private readonly List<Contact> contacts;

    public ContactService()
    {
        this.contacts = new List<Contact>();
    }
     
    public Contact Add(Contact contact)
    {
        var existContact = contacts.FirstOrDefault(c => c.Phone == contact.Phone);
        if (existContact is not null)
            throw new Exception("Contact with this number already exists...");

        contacts.Add(contact);
        return contact;
    }

    public bool Delete(int id)
    {
        var contact = contacts.FirstOrDefault(c => c.Id == id)
            ?? throw new Exception("Contact with this id was not found...");

        return contacts.Remove(contact);
    }

    public List<Contact> GetAll()
        => contacts;

    public Contact GetById(int id)
    {
        var contact = contacts.FirstOrDefault(c => c.Id == id)
            ?? throw new Exception("Contact with this id was not found...");

        return contact;
    }

    public Contact Update(int id, Contact contact)
    {
        var existingContact = contacts.FirstOrDefault(c => c.Id == id)
            ?? throw new Exception("Contact with this id was not found...");

        existingContact.Id = id;
        existingContact.Name = contact.Name;
        existingContact.Email = contact.Email;
        existingContact.Phone = contact.Phone;
        existingContact.Address = contact.Address;

        return existingContact;
    }
}
