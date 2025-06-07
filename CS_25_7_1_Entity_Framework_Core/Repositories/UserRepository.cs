using CS_25_7_1_Entity_Framework_Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_25_7_1_Entity_Framework_Core.Repositories;

/// <summary>
/// Реализация интерфейса репозитория управления пользователями.
/// </summary>
public class UserRepository : IUserRepository
{
    private readonly DbContext context;
    private readonly DbSet<User> users;

    /// <summary>
    /// Инициализирует новый экземпляр репозитория пользователей.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    public UserRepository(DbContext context)
    {
        this.context    = context;
        this.users      = context.Set<User>();
    }

    /// <summary>
    /// Реализация метода интерфейса <see cref="IUserRepository.GetById"/>
    /// </summary>
    public User? GetById(int id) => users.Include(u => u.Books).FirstOrDefault(u => u.Id == id);

    /// <summary>
    /// Реализация метода интерфейса <see cref="IUserRepository.GetAll"/>
    /// </summary>
    public List<User> GetAll() => users.Include(u => u.Books).ToList();

    /// <summary>
    /// Реализация метода интерфейса <see cref="IUserRepository.Add"/>
    /// </summary>
    public void Add(User user)
    {
        users.Add(user);

        context.SaveChanges();
    }

    /// <summary>
    /// Реализация метода интерфейса <see cref="IUserRepository.Delete"/>
    /// </summary>
    public void Delete(int id)
    {
        var user = users.Find(id);

        if (user == null) return;

        users.Remove(user);

        context.SaveChanges();
    }

    /// <summary>
    /// Реализация метода интерфейса <see cref="IUserRepository.UpdateName"/>
    /// </summary>
    public void UpdateName(int id, string newName)
    {
        var user = users.Find(id);

        if (user == null) return;

        user.Name = newName;

        context.SaveChanges();
    }
}