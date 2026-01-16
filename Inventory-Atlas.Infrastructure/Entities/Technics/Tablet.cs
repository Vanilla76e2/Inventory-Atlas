using Inventory_Atlas.Infrastructure.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace Inventory_Atlas.Infrastructure.Entities.Technics
{
    /// <summary>
    /// Сущность планшета.
    /// <para/>
    /// Наследуется от <see cref="Equipment"/> и содержит основные характеристики устройства.
    /// </summary>
    [Table("Tablets", Schema = "Technics")]
    public class Tablet : DeviceEntity, IHasIpAddress
    {
        /// <summary>
        /// Операционная система планшета.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("operating_system")]
        public string? OperatingSystem { get; set; }

        /// <summary>
        /// Диагональ экрана в дюймах.
        /// <para/>
        /// Тип: <see langword="float"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("diagonal")]
        public double? Diagonal { get; set; }

        /// <summary>
        /// Разрешение экрана.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("resolution")]
        public string? Resolution { get; set; }

        /// <summary>
        /// Объём оперативной памяти в ГБ.
        /// <para/>
        /// Тип: <see langword="int"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("ram")]
        public int? RAM { get; set; } // in GB

        /// <summary>
        /// Объём накопителя в ГБ.
        /// <para/>
        /// Тип: <see langword="int"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("drive")]
        public int? Drive { get; set; } // in GB

        /// <summary>
        /// IP адрес планшета.
        /// <para/>
        /// Тип: <see cref="IPAddress"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        public IPAddress? IpAddress { get; set; }
    }
}
