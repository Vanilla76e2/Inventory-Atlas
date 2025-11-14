using Inventory_Atlas.Core.DTOs.Common;
using System.Net;

namespace Inventory_Atlas.Core.DTOs.Dictionaries
{
    /// <summary>
    /// DTO для хранения информации об IP-адресах.
    /// <para/>
    /// Тип: <see cref="IpDictionaryDto"/>
    /// <para/>
    /// Наследуется от <see cref="AuditableDto"/> и содержит IP-адрес и заметку.
    /// </summary>0
    public class IpDictionaryDto : AuditableDto
    {
        /// <summary>
        /// IP-адрес.
        /// <para/>
        /// Тип: <see cref="IPAddress"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public IPAddress IpAddress { get; set; } = null!;

        /// <summary>
        /// Примечание или описание для IP-адреса.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string Note { get; set; } = null!;
    }
}
