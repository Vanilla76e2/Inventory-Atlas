using Inventory_Atlas.Infrastructure.Entities.Employees;
using Inventory_Atlas.Infrastructure.Repository.Common;

namespace Inventory_Atlas.Infrastructure.Repository.Employees
{
    /// <summary>
    /// Интерфейс репозитория для работы с сотрудниками.
    /// </summary>
    public interface IEmployeeRepository : IDatabaseRepository<Employee>
    {
        /// <summary>
        /// Выполняет поиск сотрудников по различным критериям.
        /// Любой из параметров можно оставить <c>null</c> для игнорирования при фильтрации.
        /// </summary>
        /// <param name="surname">Фамилия сотрудника (частичное совпадение).</param>
        /// <param name="firstname">Имя сотрудника (частичное совпадение).</param>
        /// <param name="patronymic">Отчество сотрудника (частичное совпадение).</param>
        /// <param name="departmentId">Id отдела сотрудника.</param>
        /// <param name="position">Должность сотрудника (частичное совпадение).</param>
        /// <param name="isResponsible">Фильтр по признаку ответственного лица.</param>
        /// <returns>Список сотрудников, удовлетворяющих указанным критериям поиска.</returns>
        Task<IEnumerable<Employee>> SearchAsync(
            string? surname = null,
            string? firstname = null,
            string? patronymic = null,
            int? departmentId = null,
            string? position = null,
            bool? isResponsible = null);
    }
}
