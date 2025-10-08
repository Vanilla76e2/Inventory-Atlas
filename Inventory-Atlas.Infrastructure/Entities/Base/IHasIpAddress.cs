using System.Net;

namespace Inventory_Atlas.Infrastructure.Entities.Base
{
    /// <summary>
    /// Контракт для сущностей, имеющих IP-адрес.
    /// <para/>
    /// Свойство <see cref="IP"/> должно отображаться в БД с типом <c>inet</c>.
    /// </summary>
    public interface IHasIpAddress
    {
        /// <summary>
        /// IP-адрес устройства.
        /// <para/>
        /// Тип: <see cref="IPAddress"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>, если адрес не задан.
        /// </summary>
        public IPAddress? IP { get; set; }
    }
}
