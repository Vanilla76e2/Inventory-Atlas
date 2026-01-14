using Inventory_Atlas.Application.Entities.Base;
using Inventory_Atlas.Application.Entities.Technics.Components;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Application.Entities.References
{
    /// <summary>
    /// Центральный процессор (CPU).
    /// <para/>
    /// Содержит информацию о наименовании, производителе, характеристиках и связанных компонентах.
    /// </summary>
    [Table("CPUs", Schema = "Dictionaries")]
    public class CpuDictionary : AuditableEntity
    {
        /// <summary>
        /// Название процессора.
        /// <para/>
        /// Тип: <see cref="string"/>.
        /// <para/>
        /// Обязательное поле, не может быть null.
        /// </summary>
        [Column("name")]
        public string Model { get; set; } = null!;

        /// <summary>
        /// Производитель процессора.
        /// <para/>
        /// Тип: <see cref="string"/>?.
        /// <para/>
        /// Может быть null, если производитель не указан.
        /// </summary>
        [Column("vendor")]
        public string Vendor { get; set; } = null!;

        /// <summary>
        /// Количество ядер процессора.
        /// <para/>
        /// Тип: <see cref="short"/>?.
        /// <para/>
        /// Может быть null, если информация неизвестна.
        /// </summary>
        [Column("core_count")]
        public short? CoreCount { get; set; }

        /// <summary>
        /// Количество потоков процессора.
        /// <para/>
        /// Тип: <see cref="short"/>?.
        /// <para/>
        /// Может быть null, если информация неизвестна.
        /// </summary>
        [Column("thread_count")]
        public short? ThreadCount { get; set; }

        /// <summary>
        /// Тактовая частота процессора в ГГц.
        /// <para/>
        /// Тип: <see cref="double"/>?.
        /// <para/>
        /// Может быть null, если информация неизвестна.
        /// </summary>
        [Column("сlock")]
        public double? Clock { get; set; } // in GHz

        /// <summary>
        /// Тип сокета процессора.
        /// <para/>
        /// Тип: <see cref="string"/>?.
        /// <para/>
        /// Может быть null, если информация не указана.
        /// </summary>
        [Column("socket")]
        public string? Socket { get; set; }

        /// <summary>
        /// Коллекция компонентов CPU, использующих этот процессор.
        /// <para/>
        /// Тип: <see cref="ICollection{CPUComponent}"/>.
        /// <para/>
        /// Навигационное свойство для получения всех компонентов, являющихся данным CPU.
        /// </summary>
        [InverseProperty(nameof(CpuComponent.CPUReference))]
        public virtual ICollection<CpuComponent> CPUs { get; set; } = new List<CpuComponent>();
    }
}
