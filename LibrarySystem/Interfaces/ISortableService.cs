using LibrarySystem.Entites;

namespace LibrarySystem.Interfaces;

public interface ISortableService
{
    void Sort(List<Book> books);
}
