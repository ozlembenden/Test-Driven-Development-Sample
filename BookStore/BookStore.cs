using BookStore.Abstractions;
using BookStore.Exceptions;
using BookStore.Models;

namespace BookStore
{
    public class BookStore
    {
        private readonly IBookRepository _bookRepo;
        private readonly IUserRepository _userRepo;
        private readonly IPaymentGateway _paymentGateway;

        public BookStore(IBookRepository bookRepo, IUserRepository userRepo, IPaymentGateway paymentGateway)
        {
            _bookRepo = bookRepo;
            _userRepo = userRepo;
            _paymentGateway = paymentGateway;
        }

        public bool PurchaseBook(int userId, int bookId)
        {
            User user = _userRepo.GetUserByUserId(userId);//get user by user Id
            if (user == null)
            {
                throw new UserNotFoundException(userId);
            }
            if (user.IsInBlackList)
            {
                return false;
            }
            Book book = _bookRepo.GetBookByBookId(bookId);//get book by bookId
            if (book == null)
            {
                throw new BookNotFoundException(bookId);
            }
            bool isPurchased = _paymentGateway.PurchaseBookForUser(user, book);
            return isPurchased;
        }
    }
}