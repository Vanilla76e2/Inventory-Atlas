using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Technics
{
    /// <summary>
    /// Сущность планшета.
    /// <para/>
    /// Наследуется от <see cref="Equipment"/> и содержит основные характеристики устройства.
    /// </summary>
    [Table("Tablets", Schema = "Technics")]
    public class Tablet : Equipment
    {
        /// <summary>
        /// Модель планшета.
        /// <para/>
        /// Тип: <see langword="string"/>.
        /// <para/>
        /// Обязательное поле, не может быть <see langword="null"/>.
        /// </summary>
        [Column("model")]
        public string Model { get; set; } = null!;

        /// <summary>
        /// Серийный номер планшета.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("serial_number")]
        public string? SerialNumber { get; set; }

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
        public float? Diagonal { get; set; }

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
    }
}
