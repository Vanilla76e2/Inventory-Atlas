using Inventory_Atlas.Infrastructure.Entities.Employees;
using Inventory_Atlas.Infrastructure.Repository.Common;

namespace Inventory_Atlas.Infrastructure.Repository.Employees
{
    /// <summary>
    /// Репозиторий для работы с материально ответственными лицами.
    /// </summary>
    public interface IMateriallyResponsibleRepository : IDatabaseRepository<MateriallyResponsible>
    {
        /// <summary>
        /// Выполняет поиск материально ответственных лиц по заданным критериям.
        /// Любой параметр можно оставить <c>null</c> для игнорирования при фильтрации.
        /// </summary>
        /// <param name="employeeId">Id сотрудника.</param>
        /// <param name="displayName">Отображаемое имя (частичное совпадение).</param>
        /// <param name="comment">Комментарий (частичное совпадение).</param>
        /// <returns>Список материально ответственных лиц, соответствующих критериям поиска.</returns>
        Task<IEnumerable<MateriallyResponsible>> SearchAsync(
            int? employeeId = null,
            string? displayName = null,
            string? comment = null,
            CancellationToken ct = default);
    }
}
