using System;
using System.ComponentModel.DataAnnotations;

namespace CS_25_7_1_Entity_Framework_Core.Models;

/// <summary>
/// Модель книги.
/// </summary>
public class Book
{
    /// <summary>
    /// Уникальный идентификатор книги.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Название книги.
    /// </summary>
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Автор книги.
    /// </summary>
    [MaxLength(100)]
    public string Author { get; set; } = string.Empty;

    /// <summary>
    /// Год публикации.
    /// </summary>
    public int YearOfPublication { get; set; }

    /// <summary>
    /// Жанр книги.
    /// </summary>
    [MaxLength(100)]
    public string? Genre { get; set; }

    /// <summary>
    /// ID пользователя, который взял книгу (если книга на руках).
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// Связь с пользователем, который взял книгу.
    /// </summary>
    public User? User { get; init; }
}