using CS_25_7_1_Entity_Framework_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CS_25_7_1_Entity_Framework_Core;

/// <summary>
/// Контекст базы данных
/// </summary>
public sealed class AppContext : DbContext
{
    /// <summary>
    /// Пользователи.
    /// </summary>
    public DbSet<User> Users { get; set; }

    /// <summary>
    /// Книги.
    /// </summary>
    public DbSet<Book> Books { get; set; }

    /// <summary>
    /// Инициализирует новый экземпляр класса.
    /// </summary>
    public AppContext()
    {
        Database.EnsureCreated();
    }

    /// <summary>
    /// Для тестирования
    /// </summary>
    public AppContext(DbContextOptions<AppContext> options) : base(options)
    {
        // Метод инициализации бещ Database.EnsureCreated();
        // В тестах работаем с InMemoryDatabase
    }

    /// <summary>
    /// Конфигурация строки подключения к базе данных.
    /// </summary>
    /// <param name="optionsBuilder"> <see cref="DbContextOptionsBuilder"/></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-ABTDGNN;Database=EF;Trusted_Connection=True");
        }
    }

    /// <summary>
    /// Указание связей между сущностями. Сохранение логической ссылочности.
    /// Если удаляется пользователь зачищается связь с "его" книгами.
    /// </summary>
    /// <param name="modelBuilder">Построитель модели <see cref="ModelBuilder"/></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasOne(b => b.User)
            .WithMany(u => u.Books)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}