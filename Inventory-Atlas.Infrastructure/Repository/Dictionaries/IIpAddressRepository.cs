using Inventory_Atlas.Application.Entities.Dictionaries;
using Inventory_Atlas.Application.Repository.Common;

namespace Inventory_Atlas.Application.Repository.Dictionaries
{
    /// <summary>
    /// Репозиторий для работы с IpAddress-адресами.
    /// <para/>
    /// Наследуется от <see cref="IDatabaseRepository{IpDictionary}"/>.
    /// </summary>
    public interface IIpAddressRepository : IDatabaseRepository<IpDictionary>
    {
        /// <summary>
        /// Выполняет поиск IpAddress-адресов по заданным фильтрам.
        /// </summary>
        /// <param name="ip">IpAddress-адрес (опционально, поиск по подстроке, нечувствительно к регистру).</param>
        /// <param name="note">Комментарий или описание IpAddress (опционально, поиск по подстроке, нечувствительно к регистру).</param>
        /// <returns>Список объектов <see cref="IpDictionary"/>, удовлетворяющих фильтрам.</returns>
        Task<IEnumerable<IpDictionary>> SearchAsync(string? ip = null, string? note = null, CancellationToken ct = default);
    }
}
