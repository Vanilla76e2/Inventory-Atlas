using Inventory_Atlas.Infrastructure.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace Inventory_Atlas.Infrastructure.Entities.Technics
{
    /// <summary>
    /// Сущность компьютера.
    /// <para/>
    /// Наследуется от <see cref="Equipment"/> и cодержит информацию об IP-адресе, операционной системе
    /// и связанных комплектующих.
    /// </summary>
    [Table("Computers", Schema = "Technics")]
    public class Computer : Equipment, IHasIpAddress
    {
        /// <summary>
        /// Флаг, указывающий, является ли компьютер сервером.
        /// <para/>
        /// Тип: <see langword="bool"/>.
        /// <para/>
        /// По умолчанию <see langword="false"/>.
        /// </summary>
        [Column("is_server")]
        public bool IsServer { get; set; } = false;

        /// <summary>
        /// IP-адрес компьютера.
        /// <para/>
        /// Тип: <see cref="IPAddress"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>. Хранится в PostgreSQL как <c>inet</c>.
        /// </summary>
        [Column("ip_address", TypeName = "inet")]
        public IPAddress? IpAddress { get; set; }

        /// <summary>
        /// Операционная система, установленная на компьютере.
        /// <para/>
        /// Тип: <see langword="string"/>.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("operating_system")]
        public string? OperatingSystem { get; set; }

        /// <summary>
        /// Коллекция комплектующих компьютера.
        /// <para/>
        /// Тип: <see cref="ICollection{ComputerComponent}"/> с элементами <see cref="ComputerComponent"/>.
        /// <para/>
        /// Не может быть <see langword="null"/> (инициализируется пустым списком).
        /// </summary>
        [InverseProperty(nameof(ComputerComponent.Computer))]
        public virtual ICollection<ComputerComponent> ComputerComponents { get; set; } = new List<ComputerComponent>();
    }
}
