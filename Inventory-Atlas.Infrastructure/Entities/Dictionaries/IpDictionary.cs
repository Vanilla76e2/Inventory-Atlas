using Inventory_Atlas.Application.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace Inventory_Atlas.Application.Entities.Dictionaries
{
    /// <summary>
    /// Сущность для аудита IpAddress-адресов.
    /// <para/>
    /// Наследуется от <see cref="AuditableEntity"/> и хранит IpAddress-адрес и заметку.
    /// </summary>
    [Table("IpAddresses", Schema = "Dictionary")]
    public class IpDictionary : AuditableEntity
    {
        /// <summary>
        /// IpAddress-адрес устройства или пользователя.
        /// <para/>
        /// Тип: <see cref="IPAddress"/>.
        /// <para/>
        /// Не может быть <see langword="null"/>.
        /// </summary>
        [Column("ip", TypeName = "inet")]
        public IPAddress IpAddress { get; set; } = null!;

        /// <summary>
        /// Заметка или комментарий.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Не может быть <see langword="null"/>.
        /// </summary>
        [Column("note")]
        public string Note { get; set; } = null!;
    }
}
