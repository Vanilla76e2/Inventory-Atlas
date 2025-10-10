using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Repository.Common;

namespace Inventory_Atlas.Infrastructure.Repository.Technics
{
    /// <summary>
    /// Репозиторий для работы с оборудованием
    /// </summary>
    public interface IEquipmentRepository : IDatabaseRepository<Equipment>
    {
        /// <summary>
        /// Получает оборудование с связанными рабочими местами и журналом обслуживания
        /// </summary>
        /// <param name="equipmentId">Идентификатор оборудования</param>
        /// <returns>Оборудование с связанными данными или null если не найден</returns>
        Task<Equipment?> GetWithWorkplacesAndMaintenanceAsync(int equipmentId);

        /// <summary>
        /// Получает оборудование по идентификатору рабочего места
        /// </summary>
        /// <param name="workplaceId">Идентификатор рабочего места</param>
        /// <returns>Коллекция оборудования на указанном рабочем месте</returns>
        Task<IEnumerable<Equipment>> GetByWorkplaceIdAsync(int workplaceId);
    }
}