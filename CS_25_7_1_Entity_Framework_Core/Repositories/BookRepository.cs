using CS_25_7_1_Entity_Framework_Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
namespace CS_25_7_1_Entity_Framework_Core.Repositories;

/// <summary>
/// Реализация интерфейса репозитория управления книгами.
/// </summary>
public class BookRepository : IBookRepository
{
    private readonly DbContext context;
    private readonly DbSet<Book> books;

    /// <summary>
    /// Инициализирует новый экземпляр класса.
    /// </summary>
    /// <param name="context"> <see cref="DbContext"/></param>
    public BookRepository(DbContext context)
    {
        this.context    = context;
        this.books      = context.Set<Book>();
    }

    /// <summary>
    /// Реализация метода интерфейса <see cref="IBookRepository.GetById"/>
    /// </summary>
    public Book? GetById(int id) => books.Include(b => b.User).FirstOrDefault(b => b.Id == id);

    /// <summary>
    /// Реализация метода интерфейса <see cref="IBookRepository.GetAll"/>
    /// </summary>
    public List<Book> GetAll() => books.Include(b => b.User).ToList();

    /// <summary>
    /// Реализация метода интерфейса <see cref="IBookRepository.Add"/>
    /// </summary>
    public void Add(Book book)
    {
        books.Add(book);
        context.SaveChanges();
    }

    /// <summary>
    /// Реализация метода интерфейса <see cref="IBookRepository.Delete"/>
    /// </summary>
    public void Delete(int id)
    {
        var book = books.Find(id);
        if (book == null) return;
        books.Remove(book);
        context.SaveChanges();
    }

    /// <summary>
    /// Реализация метода интерфейса <see cref="IBookRepository.UpdateYearOfPublication"/>
    /// </summary>
    public void UpdateYearOfPublication(int id, int newYear)
    {
        var book = books.Find(id);

        if (book == null) return;

        book.YearOfPublication = newYear;

        context.SaveChanges();
    }

    /// <summary>
    /// Реализация метода интерфейса <see cref="IBookRepository.UpdateAuthorAndGenre"/>
    /// </summary>
    public void UpdateAuthorAndGenre(int id, string newAuthor, string newGenre)
    {
        var book = books.Find(id);

        if (book == null) return;

        book.Author = newAuthor;
        book.Genre  = newGenre;

        context.SaveChanges();
    }

    /// <summary>
    /// Реализация метода интерфейса <see cref="IBookRepository.AssignBookToUser"/>
    /// </summary>
    public void AssignBookToUser(int bookId, int userId)
    {
        var book = books.Find(bookId);

        if (book == null) return;

        book.UserId = userId;

        context.SaveChanges();
    }

    /// <summary>
    /// Реализация метода интерфейса <see cref="IBookRepository.GetBooksByGenreAndYearRange"/>
    /// </summary>
    public List<Book> GetBooksByGenreAndYearRange(string genre, int startYear, int endYear) =>
        books.Where(b => b.Genre == genre && b.YearOfPublication >= startYear && b.YearOfPublication <= endYear).ToList();

    /// <summary>
    /// Реализация метода интерфейса <see cref="IBookRepository.GetBookCountByAuthor"/>
    /// </summary>
    public int GetBookCountByAuthor(string author) =>
        books.Count(b => b.Author == author);

    /// <summary>
    /// Реализация метода интерфейса <see cref="IBookRepository.GetBookCountByGenre"/>
    /// </summary>
    public int GetBookCountByGenre(string genre) =>
        books.Count(b => b.Genre == genre);

    /// <summary>
    /// Реализация метода интерфейса <see cref="IBookRepository.IsBookAvailable"/>
    /// </summary>
    public bool IsBookAvailable(string author, string title) =>
        books.Any(b => b.Author == author && b.Name == title);

    /// <summary>
    /// Реализация метода интерфейса <see cref="IBookRepository.IsBookWithUser"/>
    /// </summary>
    public bool IsBookWithUser(int bookId) =>
        books.Any(b => b.Id == bookId && b.UserId != null);

    /// <summary>
    /// Реализация метода интерфейса <see cref="IBookRepository.GetUserBookCount"/>
    /// </summary>
    public int GetUserBookCount(int userId) =>
        books.Count(b => b.UserId == userId);

    /// <summary>
    /// Реализация метода интерфейса <see cref="IBookRepository.GetLatestBook"/>
    /// </summary>
    public Book? GetLatestBook() =>
        books.OrderByDescending(b => b.YearOfPublication).FirstOrDefault();

    /// <summary>
    /// Реализация метода интерфейса <see cref="IBookRepository.GetBooksSortedByTitle"/>
    /// </summary>
    public List<Book> GetBooksSortedByTitle() =>
        books.OrderBy(b => b.Name).ToList();

    /// <summary>
    /// Реализация метода интерфейса <see cref="IBookRepository.GetBooksSortedByYearDesc"/>
    /// </summary>
    public List<Book> GetBooksSortedByYearDesc() =>
        books.OrderByDescending(b => b.YearOfPublication).ToList();
}