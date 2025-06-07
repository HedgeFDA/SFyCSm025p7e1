using CS_25_7_1_Entity_Framework_Core;

namespace CS_25_7_1_Entity_Framework_Core;

class Program
{
    /// <summary>
    /// Процедура реализующая основной алгоритм работы программы.
    /// </summary>
    static void PerformMain()
    {
        using var db = new AppContext();
    }

    /// <summary>
    /// Главная точка входа приложения
    /// </summary>
    /// <param name="args">Аргументы командной строки при запуске приложения.</param>
    static void Main(string[] args)
    {
        PerformMain();
    }
}