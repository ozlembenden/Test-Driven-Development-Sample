using BookStore.Models;

namespace BookStore.Abstractions
{
    public interface IBookRepository
    {
        Book GetBookByBookId(int bookId);
    }
}