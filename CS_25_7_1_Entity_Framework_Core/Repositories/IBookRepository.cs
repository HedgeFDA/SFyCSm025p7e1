using CS_25_7_1_Entity_Framework_Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CS_25_7_1_Entity_Framework_Core.Repositories;

/// <summary>
/// Интерфейс репозитория для управления книгами в базе данных.
/// </summary>
public interface IBookRepository
{
    /// <summary>
    /// Получает книгу по её идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор книги.</param>
    /// <returns>Объект книги или null, если книга не найдена.</returns>
    Book? GetById(int id);

    /// <summary>
    /// Получает список всех книг.
    /// </summary>
    /// <returns>Список книг.</returns>
    List<Book> GetAll();

    /// <summary>
    /// Добавляет книгу в базу данных.
    /// </summary>
    /// <param name="book">Объект книги <see cref="Book"/></param>
    void Add(Book book);

    /// <summary>
    /// Удаляет книгу из базы данных по её идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор книги.</param>
    void Delete(int id);

    /// <summary>
    /// Обновляет год публикации книги.
    /// </summary>
    /// <param name="id">Идентификатор книги.</param>
    /// <param name="newYear">Новый год публикации.</param>
    void UpdateYearOfPublication(int id, int newYear);

    /// <summary>
    /// Обновляет автора и жанр книги.
    /// </summary>
    /// <param name="id">Идентификатор книги.</param>
    /// <param name="newAuthor">Новый автор.</param>
    /// <param name="newGenre">Новый жанр.</param>
    void UpdateAuthorAndGenre(int id, string newAuthor, string newGenre);

    /// <summary>
    /// Привязывает книгу к пользователю.
    /// </summary>
    /// <param name="bookId">Идентификатор книги.</param>
    /// <param name="userId">Идентификатор пользователя.</param>
    void AssignBookToUser(int bookId, int userId);

    /// <summary>
    /// Получает список книг заданного жанра, опубликованных в указанном диапазоне лет.
    /// </summary>
    /// <param name="genre">Жанр</param>
    /// <param name="startYear">Начальный год диапозона</param>
    /// <param name="endYear">Конечный год диапозона</param>
    List<Book> GetBooksByGenreAndYearRange(string genre, int startYear, int endYear);

    /// <summary>
    /// Возвращает количество книг указанного автора.
    /// </summary>
    /// <param name="author">Автор</param>
    int GetBookCountByAuthor(string author);

    /// <summary>
    /// Возвращает количество книг указанного жанра.
    /// </summary>
    /// <param name="genre">Жанр</param>
    int GetBookCountByGenre(string genre);

    /// <summary>
    /// Проверяет наличие книги в библиотеке по автору и названию.
    /// </summary>
    /// <param name="author">Автор</param>
    /// <param name="title">Название</param>
    bool IsBookAvailable(string author, string title);

    /// <summary>
    /// Проверяет, находится ли книга у пользователя на руках.
    /// </summary>
    /// <param name="bookId">Идентификатор книги.</param>
    bool IsBookWithUser(int bookId);

    /// <summary>
    /// Возвращает количество книг, находящихся у пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    int GetUserBookCount(int userId);

    /// <summary>
    /// Получает последнюю вышедшую книгу.
    /// </summary>
    Book? GetLatestBook();

    /// <summary>
    /// Получает список всех книг, отсортированный по названию в алфавитном порядке.
    /// </summary>
    List<Book> GetBooksSortedByTitle();

    /// <summary>
    /// Получает список всех книг, отсортированный по году публикации (убывание).
    /// </summary>
    List<Book> GetBooksSortedByYearDesc();
}