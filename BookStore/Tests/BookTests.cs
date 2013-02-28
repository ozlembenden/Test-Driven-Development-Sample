using BookStore.Abstractions;
using BookStore.Models;
using Moq;
using NUnit.Framework;

namespace BookStore.Tests
{
    [TestFixture]
    public class BookTests
    {
        //Testable Object Pattern

        //- Users can buy book
        //- Users Can Not Buy Book If The User Is In Black List
        //- Users can have discount while buying book if they are subscribed

        [Test]
        public void UsersCanBuyBook()
        {
            //DRY
            var bookStore = TestableBookStore.Create(new Book(), new User());
            bookStore.PaymentGatewayMock.Setup(gateway => gateway.PurchaseBookForUser(It.IsAny<User>(), It.IsAny<Book>()))
                          .Returns(true);
            const int userId = 45;
            const int bookId = 0;
            var isPurchased = bookStore.PurchaseBook(userId, bookId);

            bookStore.PaymentGatewayMock.Verify(gateway => gateway.PurchaseBookForUser(It.IsAny<User>(), It.IsAny<Book>()), Times.Once());
            Assert.IsTrue(isPurchased);
        }

        [Test]
        public void UsersCanNotBuyBookIfTheUserIsInBlackList()
        {
            var bookStore = TestableBookStore.Create(null, new User { IsInBlackList = true });
            const int userId = 45;
            const int bookId = 0;
            var isPurchased = bookStore.PurchaseBook(userId, bookId);
            bookStore.PaymentGatewayMock.Verify(gateway => gateway.PurchaseBookForUser(It.IsAny<User>(), It.IsAny<Book>()), Times.Never());
            Assert.IsFalse(isPurchased);
        }
    }
}