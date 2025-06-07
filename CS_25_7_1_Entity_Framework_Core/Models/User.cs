using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CS_25_7_1_Entity_Framework_Core.Models;

/// <summary>
/// Модель пользователя.
/// </summary>
public class User
{
    /// <summary>
    /// Уникальный идентификатор пользователя.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Имя пользователя.
    /// </summary>
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Email пользователя.
    /// </summary>
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Роль пользователя (например, администратор, читатель).
    /// </summary>
    [MaxLength(100)]
    public string Role { get; set; } = "читатель";

    /// <summary>
    /// Книги у пользователя.
    /// </summary>
    public List<Book> Books { get; set; } = new();
}