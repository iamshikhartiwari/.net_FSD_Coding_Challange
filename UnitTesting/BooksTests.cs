using Book_CodingChallange.Controllers;
using Book_CodingChallange.Dto;
using Book_CodingChallange.Repository;
using Moq;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Book_CodingChallange.BooksDBContext;

namespace Book_CodingChallange.Tests
{
    [TestFixture]
    public class BooksControllerTests
    {
        private Mock<IBooksRepository> _mockRepo;
        private BooksController _controller;
        private Mock<BookDBContext> _mockContext;

        [SetUp]
        public void SetUp()
        {
            _mockRepo = new Mock<IBooksRepository>();
            _mockContext = new Mock<BookDBContext>();
            _controller = new BooksController(_mockRepo.Object,_mockContext.Object);
        }

        // Test for GetAllBooks
        [Test]
        public async Task GetAllBooks_ReturnsOkResult_WhenBooksExist()
        {
            var books = new List<BookReadDto>
            {
                new BookReadDto { ISBN = "12345", Title = "Test Book 1", Author = "Author 1" },
                new BookReadDto { ISBN = "67890", Title = "Test Book 2", Author = "Author 2" }
            };

            // Mock only the required method for this test
            _mockRepo.Setup(repo => repo.GetAllBooks()).Returns(books);

            var result = await _controller.GetAllBooks();
            var okResult = result as OkObjectResult;

            // Assertions
            Assert.IsInstanceOf<OkObjectResult>(result); // Corrected assertion
            Assert.AreEqual(books.Count, ((List<BookReadDto>)okResult.Value).Count);
        }

        // Test for GetBookByIsbn
        [Test]
        public async Task GetBookByIsbn_ReturnsNotFound_WhenBookDoesNotExist()
        {
            // Mock only the necessary method for this test
            _mockRepo.Setup(repo => repo.GetBookByIsbn("99999")).Returns((BookReadDto)null);

            var result = await _controller.GetBookByIsbn("99999");
            Assert.IsInstanceOf<NotFoundResult>(result); // Corrected assertion
        }
    }
}