using CS_25_7_1_Entity_Framework_Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CS_25_7_1_Entity_Framework_Core.Repositories;

/// <summary>
/// Интерфейс репозитория для работы с пользователями.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Получает пользователя по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор пользователя.</param>
    /// <returns>Объект пользователя или null, если пользователь не найден.</returns>
    User? GetById(int id);

    /// <summary>
    /// Получает список всех пользователей.
    /// </summary>
    /// <returns>Список пользователей.</returns>
    List<User> GetAll();

    /// <summary>
    /// Добавляет нового пользователя.
    /// </summary>
    /// <param name="user">Объект пользователя.</param>
    void Add(User user);

    /// <summary>
    /// Удаляет пользователя по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор пользователя.</param>
    void Delete(int id);

    /// <summary>
    /// Обновляет имя пользователя.
    /// </summary>
    /// <param name="id">Идентификатор пользователя.</param>
    /// <param name="newName">Новое имя пользователя.</param>
    void UpdateName(int id, string newName);
}