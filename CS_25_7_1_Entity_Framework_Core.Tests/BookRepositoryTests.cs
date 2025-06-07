using NUnit.Framework;
using CS_25_7_1_Entity_Framework_Core.Models;
using CS_25_7_1_Entity_Framework_Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CS_25_7_1_Entity_Framework_Core.Tests.Repositories;

/// <summary>
/// Класс юнит-тестов для для класса BookRepository.
/// </summary>
[TestFixture]
public class BookRepositoryTests
{
    /// <summary>
    /// Проверка добавления книги в базу данных
    /// </summary>    
    [Test]
    public void AddBook_ShouldAddBookToDatabase()
    {
        var options = new DbContextOptionsBuilder<AppContext>()
            .UseInMemoryDatabase(databaseName: $"TestDb_{Guid.NewGuid()}")
            .Options;

        using var context = new AppContext(options);
        var repo = new BookRepository(context);

        var book = new Book { Name = "Test Book", Author = "Test Author", YearOfPublication = 2023 };

        repo.Add(book);

        var books = repo.GetAll();

        Assert.That(books, Has.Exactly(1).Items);
        Assert.That(books[0].Name, Is.EqualTo("Test Book"));
        Assert.That(books[0].Author, Is.EqualTo("Test Author"));
        Assert.That(books[0].YearOfPublication, Is.EqualTo(2023));
    }
}