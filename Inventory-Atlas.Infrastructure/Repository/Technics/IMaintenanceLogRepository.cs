using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Application.Entities.Technics;
using Inventory_Atlas.Application.Repository.Common;

namespace Inventory_Atlas.Application.Repository.Technics
{
    /// <summary>
    /// Репозиторий для работы с журналом технического обслуживания
    /// </summary>
    public interface IMaintenanceLogRepository : IDatabaseRepository<MaintenanceLog>
    {
        /// <summary>
        /// Получает записи обслуживания по идентификатору устройства
        /// </summary>
        /// <param name="deviceId">Идентификатор устройства</param>
        /// <returns>Коллекция записей обслуживания для указанного устройства</returns>
        Task<IEnumerable<MaintenanceLog>> GetByDeviceIdAsync(int deviceId, CancellationToken ct = default);

        /// <summary>
        /// Получает записи обслуживания по идентификатору сотрудника
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <returns>Коллекция записей обслуживания, выполненных указанным сотрудником</returns>
        Task<IEnumerable<MaintenanceLog>> GetByEmployeeIdAsync(int employeeId, CancellationToken ct = default);

        /// <summary>
        /// Получает записи обслуживания за указанный период времени
        /// </summary>
        /// <param name="from">Начальная дата периода</param>
        /// <param name="to">Конечная дата периода</param>
        /// <returns>Коллекция записей обслуживания за указанный период</returns>
        Task<IEnumerable<MaintenanceLog>> GetByDateRangeAsync(DateTime from, DateTime to, CancellationToken ct = default);

        /// <summary>
        /// Получает записи обслуживания по типу обслуживания
        /// </summary>
        /// <param name="type">Тип обслуживания</param>
        /// <returns>Коллекция записей обслуживания указанного типа</returns>
        Task<IEnumerable<MaintenanceLog>> GetByMaintenanceTypeAsync(MaintenanceType type, CancellationToken ct = default);
    }
}