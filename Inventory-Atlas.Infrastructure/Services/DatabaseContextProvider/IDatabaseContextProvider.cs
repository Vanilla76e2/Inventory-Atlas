using Inventory_Atlas.Infrastructure.Data;

/// <summary>
/// Провайдер контекста базы данных
/// </summary>
public interface IDatabaseContextProvider
{
    /// <summary>
    /// Возвращает экземпляр контекста базы данных.
    /// </summary>
    /// <returns>Экземпляр <see cref="DbContext"/>.</returns>
    Task<AppDbContext> GetDbContextAsync();

    /// <summary>
    /// Возвращает экземпляр контекста базы данных с указанной строкой подключения.
    /// </summary>
    /// <param name="connectionString">Строка подключения к базе данных.</param>
    /// <returns>Экземпляр <see cref="DbContext"/>.</returns>
    AppDbContext GetDbContext(string connectionString);
}