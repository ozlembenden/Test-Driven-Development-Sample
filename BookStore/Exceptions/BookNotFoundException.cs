using System;

namespace BookStore.Exceptions
{
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException(int bookId)
            : base(string.Format("Book '{0}' not found.", bookId))
        {

        }
    }
}