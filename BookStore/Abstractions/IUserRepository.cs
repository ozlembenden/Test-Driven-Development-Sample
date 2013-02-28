using BookStore.Models;

namespace BookStore.Abstractions
{
    public interface IUserRepository
    {
        User GetUserByUserId(int userId);
    }
}