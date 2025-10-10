using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Infrastructure.Entities.References;
using Inventory_Atlas.Infrastructure.Repository.Common;

namespace Inventory_Atlas.Infrastructure.Repository.Dictionaries
{
    /// <summary>
    /// Репозиторий для работы с графическими процессорами (GPU).
    /// <para/>
    /// Наследуется от <see cref="IDatabaseRepository{GpuDictionary}"/>.
    /// </summary>
    public interface IGpuRepository : IDatabaseRepository<GpuDictionary>
    {
        /// <summary>
        /// Выполняет поиск видеокарт по заданным фильтрам.
        /// </summary>
        /// <param name="vendor">Производитель видеокарты (опционально, поиск по подстроке, нечувствительно к регистру).</param>
        /// <param name="model">Модель видеокарты (опционально, поиск по подстроке, нечувствительно к регистру).</param>
        /// <param name="memorySize">Объём видеопамяти в МБ (опционально).</param>
        /// <param name="memoryType">Тип памяти видеокарты (опционально).</param>
        /// <param name="vga">Количество VGA-портов (опционально).</param>
        /// <param name="hdmi">Количество HDMI-портов (опционально).</param>
        /// <param name="displayPort">Количество DisplayPort-портов (опционально).</param>
        /// <param name="dvi">Количество DVI-портов (опционально).</param>
        /// <returns>Список объектов <see cref="GpuDictionary"/>, удовлетворяющих фильтрам.</returns>
        Task<IEnumerable<GpuDictionary>> SearchAsync(
            string? vendor = null,
            string? model = null,
            int? memorySize = null,
            GpuMemoryType? memoryType = null,
            short? vga = null,
            short? hdmi = null,
            short? displayPort = null,
            short? dvi = null);
    }
}
