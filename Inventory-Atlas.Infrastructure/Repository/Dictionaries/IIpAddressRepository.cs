using Inventory_Atlas.Infrastructure.Entities.Dictionaries;
using Inventory_Atlas.Infrastructure.Repository.Common;

namespace Inventory_Atlas.Infrastructure.Repository.Dictionaries
{
    /// <summary>
    /// Репозиторий для работы с IP-адресами.
    /// <para/>
    /// Наследуется от <see cref="IDatabaseRepository{IpDictionary}"/>.
    /// </summary>
    public interface IIpAddressRepository : IDatabaseRepository<IpDictionary>
    {
        /// <summary>
        /// Выполняет поиск IP-адресов по заданным фильтрам.
        /// </summary>
        /// <param name="ip">IP-адрес (опционально, поиск по подстроке, нечувствительно к регистру).</param>
        /// <param name="note">Комментарий или описание IP (опционально, поиск по подстроке, нечувствительно к регистру).</param>
        /// <returns>Список объектов <see cref="IpDictionary"/>, удовлетворяющих фильтрам.</returns>
        Task<IEnumerable<IpDictionary>> SearchAsync(string? ip = null, string? note = null);
    }
}
