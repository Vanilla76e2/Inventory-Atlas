using Inventory_Atlas.Infrastructure.Entities.Employees;
using Inventory_Atlas.Infrastructure.Repository.Common;

namespace Inventory_Atlas.Infrastructure.Repository.Inventory
{
    /// <summary>
    /// Репозиторий для работы с рабочими местами сотрудников.
    /// </summary>
    public interface IWorkplaceRepository : IDatabaseRepository<Workplace>
    {
        /// <summary>
        /// Выполняет поиск рабочих мест по заданным критериям.
        /// Любой параметр можно оставить <c>null</c>, чтобы не фильтровать по нему.
        /// </summary>
        /// <param name="employeeId">Id сотрудника, которому назначено рабочее место.</param>
        /// <param name="name">Название рабочего места (подстрока для поиска).</param>
        /// <param name="comment">Комментарий к рабочему месту (подстрока для поиска).</param>
        /// <returns>Список рабочих мест, удовлетворяющих заданным критериям.</returns>
        Task<IEnumerable<Workplace>> SearchAsync(
            int? employeeId = null,
            string? name = null,
            string? comment = null);
    }
}
