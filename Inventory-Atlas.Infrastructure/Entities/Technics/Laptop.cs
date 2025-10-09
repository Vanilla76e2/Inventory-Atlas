using Inventory_Atlas.Infrastructure.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace Inventory_Atlas.Infrastructure.Entities.Technics
{
    /// <summary>
    /// Сущность ноутбука.
    /// <para/>
    /// Наследуется от <see cref="Equipment"/> и содержит характеристики устройства:
    /// модель, серийный номер, диагональ экрана, разрешение, ОС, процессор, ОЗУ, накопитель и GPU.
    /// </summary>
    [Table("Laptops", Schema = "Technics")]
    public class Laptop : DeviceEntity, IHasIpAddress
    {
        /// <summary>
        /// Диагональ экрана в дюймах.
        /// <para/>
        /// Тип: <see langword="double"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("diagonal")]
        public double? Diagonal { get; set; } // in inches


        /// <summary>
        /// Разрешение экрана.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>. Ограничение длины 50 символов.
        /// </summary>
        [Column("resolution")]
        [StringLength(50)]
        public string? Resolution { get; set; }

        /// <summary>
        /// Операционная система.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>. Ограничение длины 255 символов.
        /// </summary>
        [Column("operating_system")]
        [StringLength(255)]
        public string? OperatingSystem { get; set; }

        /// <summary>
        /// Модель процессора.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>. Ограничение длины 255 символов.
        /// </summary>
        [Column("processor")]
        [StringLength(255)]
        public string? Processor { get; set; }

        /// <summary>
        /// Объём оперативной памяти в гигабайтах.
        /// <para/>
        /// Тип: <see langword="int"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("ram")]
        public int? RAM { get; set; } // in GB

        /// <summary>
        /// Объём накопителя в гигабайтах.
        /// <para/>
        /// Тип: <see langword="int"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("drive")]
        public int? Drive { get; set; } // in GB

        /// <summary>
        /// Модель видеокарты (GPU).
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>. Ограничение длины 255 символов.
        /// </summary>
        [Column("gpu")]
        [StringLength(255)]
        public string? GPU { get; set; }

        [Column("ip_address")]
        public IPAddress? IpAddress { get; set; }
    }
}
