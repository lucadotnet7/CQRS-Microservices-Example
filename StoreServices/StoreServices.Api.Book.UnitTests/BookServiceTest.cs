using AutoMapper;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using StoreServices.API.Book.Application;
using StoreServices.API.Book.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StoreServices.Api.Book.UnitTests
{
    public class BookServiceTest
    {
        private Mock<BookContext> CreateContext() 
        {
            IQueryable<API.Book.Models.Book> data = BookList().AsQueryable();
            Mock<DbSet<API.Book.Models.Book>> dbSetMock = new Mock<DbSet<API.Book.Models.Book>>();

            dbSetMock.As<IQueryable<API.Book.Models.Book>>().Setup(x => x.Provider).Returns(data.Provider);
            dbSetMock.As<IQueryable<API.Book.Models.Book>>().Setup(x => x.Expression).Returns(data.Expression);
            dbSetMock.As<IQueryable<API.Book.Models.Book>>().Setup(x => x.ElementType).Returns(data.ElementType);
            dbSetMock.As<IQueryable<API.Book.Models.Book>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());
        }

        [Fact]
        public void GetBooks()
        {
            var mockContext = new Mock<BookContext>();
            var mockMapper = new Mock<IMapper>();

            Get.Handler handlerInstance = new Get.Handler(mockContext.Object, mockMapper.Object);


        }

        private IEnumerable<API.Book.Models.Book> BookList()
        {
            A.Configure<API.Book.Models.Book>()
                .Fill(x => x.Title).AsArticleTitle()
                .Fill(x => x.Id, () => { return new Random().Next(0, 1000); });

            List<API.Book.Models.Book> books = A.ListOf<API.Book.Models.Book>(30);
            books[0].Id = 0;

            return books;
        }
    }
}
