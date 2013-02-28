using System;

namespace BookStore.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(int userId)
            : base(string.Format("User '{0}' not found.", userId))
        {

        }
    }
}