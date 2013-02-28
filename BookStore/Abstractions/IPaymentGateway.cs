using BookStore.Models;

namespace BookStore.Abstractions
{
    public interface IPaymentGateway
    {
        bool PurchaseBookForUser(User user, Book book);
    }
}