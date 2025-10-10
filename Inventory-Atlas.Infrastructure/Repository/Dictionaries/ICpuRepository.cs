using Inventory_Atlas.Infrastructure.Entities.References;
using Inventory_Atlas.Infrastructure.Repository.Common;

namespace Inventory_Atlas.Infrastructure.Repository.Dictionaries
{
    /// <summary>
    /// Репозиторий для работы с процессорами (CPU).
    /// <para/>
    /// Наследуется от <see cref="IDatabaseRepository{CpuDictionary}"/>.
    /// </summary>
    public interface ICpuRepository : IDatabaseRepository<CpuDictionary>
    {
        /// <summary>
        /// Выполняет поиск процессоров по заданным фильтрам.
        /// </summary>
        /// <param name="name">Название процессора (опционально, поиск по подстроке, нечувствительно к регистру).</param>
        /// <param name="vendor">Производитель процессора (опционально, поиск по подстроке, нечувствительно к регистру).</param>
        /// <param name="cores">Количество ядер процессора (опционально).</param>
        /// <param name="threads">Количество потоков процессора (опционально).</param>
        /// <param name="clock">Тактовая частота процессора в ГГц (опционально).</param>
        /// <param name="tolerance">Допустимое отклонение для сравнения тактовой частоты (по умолчанию 0.01 ГГц).</param>
        /// <param name="socket">Тип сокета процессора (опционально, поиск по подстроке, нечувствительно к регистру).</param>
        /// <returns>Список процессоров <see cref="CpuDictionary"/>, удовлетворяющих фильтрам.</returns>
        Task<IEnumerable<CpuDictionary>> SearchAsync(
            string? name = null,
            string? vendor = null,
            int? cores = null,
            int? threads = null,
            double? clock = null,
            double tolerance = 0.01,
            string? socket = null);
    }
}
