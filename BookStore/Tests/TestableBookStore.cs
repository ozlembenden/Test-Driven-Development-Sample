using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Abstractions;
using BookStore.Models;
using Moq;

namespace BookStore.Tests
{
    public class TestableBookStore : BookStore
    {
        public readonly Mock<IBookRepository> BookRepoMock;
        public readonly Mock<IUserRepository> UserRepoMock;
        public readonly Mock<IPaymentGateway> PaymentGatewayMock;

        TestableBookStore(Mock<IBookRepository> bookRepoMock, Mock<IUserRepository> userRepoMock, Mock<IPaymentGateway> paymentGatewayMock) :
            base(bookRepoMock.Object, userRepoMock.Object, paymentGatewayMock.Object)
        {
            BookRepoMock = bookRepoMock;
            UserRepoMock = userRepoMock;
            PaymentGatewayMock = paymentGatewayMock;
        }

        public static TestableBookStore Create(Book defaultBookStub, User defaultUserStub)
        {
            var paymentGatewayMock = new Mock<IPaymentGateway>();
            var userRepoMock = new Mock<IUserRepository>();
            var bookRepoMock = new Mock<IBookRepository>();
            userRepoMock.Setup(repository => repository.GetUserByUserId(It.IsAny<int>())).Returns(defaultUserStub);
            bookRepoMock.Setup(repository => repository.GetBookByBookId(It.IsAny<int>())).Returns(defaultBookStub);
            return new TestableBookStore(bookRepoMock, userRepoMock, paymentGatewayMock);
        }
    }
}
