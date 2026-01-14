using Inventory_Atlas.Application.Entities.Employees;
using Inventory_Atlas.Application.Repository.Common;

namespace Inventory_Atlas.Application.Repository.Employees
{
    /// <summary>
    /// Интерфейс репозитория для работы с отделами.
    /// </summary>
    public interface IDepartmentRepository : IDatabaseRepository<Department>
    {
        /// <summary>
        /// Выполняет поиск отделов по частичному или полному совпадению имени.
        /// </summary>
        /// <param name="name">Частичное или полное имя отдела для поиска.</param>
        /// <returns>Список отделов, соответствующих критерию поиска.</returns>
        Task<IEnumerable<Department>> SearchByNameAsync(string name, CancellationToken ct = default);
    }
}
