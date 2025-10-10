using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Infrastructure.Entities.References;
using Inventory_Atlas.Infrastructure.Repository.Common;

namespace Inventory_Atlas.Infrastructure.Repository.Dictionaries
{
    /// <summary>
    /// Репозиторий для работы с материнскими платами (MoBo).
    /// <para/>
    /// Наследуется от <see cref="IDatabaseRepository{MoBoDictionary}"/>.
    /// </summary>
    public interface IMoBoRepository : IDatabaseRepository<MoBoDictionary>
    {
        /// <summary>
        /// Выполняет поиск материнских плат по заданным фильтрам.
        /// </summary>
        /// <param name="vendor">Производитель (опционально, поиск по подстроке, нечувствительно к регистру).</param>
        /// <param name="model">Модель платы (опционально, поиск по подстроке, нечувствительно к регистру).</param>
        /// <param name="socket">Тип сокета (опционально).</param>
        /// <param name="chipset">Чипсет платы (опционально).</param>
        /// <param name="formFactor">Форм-фактор платы (опционально).</param>
        /// <param name="ramSlots">Количество слотов RAM (опционально).</param>
        /// <param name="m2Slots">Количество M.2 слотов (опционально).</param>
        /// <returns>Список объектов <see cref="MoBoDictionary"/>, удовлетворяющих фильтрам.</returns>
        Task<IEnumerable<MoBoDictionary>> SearchAsync(
            string? vendor = null,
            string? model = null,
            string? socket = null,
            string? chipset = null,
            MoBoFormFactor? formFactor = null,
            short? ramSlots = null,
            short? m2Slots = null);
    }
}
