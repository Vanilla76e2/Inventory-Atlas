using Inventory_Atlas.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using Inventory_Atlas.Infrastructure.Entities.Base;
using Inventory_Atlas.Infrastructure.Entities.Technics.Components;

namespace Inventory_Atlas.Infrastructure.Entities.Dictionaries
{
    /// <summary>
    /// Видеокарта (GPU).
    /// <para/>
    /// Содержит информацию о производителе, модели, объёме и типе памяти,
    /// портах подключения и связанных компонентах.
    /// </summary>
    [Table("GPUs", Schema = "Dictionaries")]
    public class GpuDictionary : AuditableEntity
    {
        /// <summary>
        /// Производитель видеокарты.
        /// <para/>
        /// Тип: <see cref="string"/>.
        /// <para/>
        /// Обязательное поле, не может быть null.
        /// </summary>
        [Column("vendor")]
        public string Vendor { get; set; } = null!;

        /// <summary>
        /// Модель видеокарты.
        /// <para/>
        /// Тип: <see cref="string"/>.
        /// <para/>
        /// Обязательное поле, не может быть null.
        /// </summary>
        [Column("Model")]
        public string Model { get; set; } = null!;

        /// <summary>
        /// Объём видеопамяти в Гигабайтах.
        /// <para/>
        /// Тип: <see cref="int"/>.
        /// </summary>
        [Column("memory_size")]
        public int MemorySize { get; set; } // in Gb

        /// <summary>
        /// Тип видеопамяти.
        /// <para/>
        /// Тип: <see cref="GpuMemoryType"/>.
        /// </summary>
        [Column("memory_type")]
        public GpuMemoryType MemoryType { get; set; }

        /// <summary>
        /// Количество VGA-портов.
        /// <para/>
        /// Тип: <see cref="short"/>?.
        /// <para/>
        /// Может быть null, если порт отсутствует.
        /// </summary>
        [Column("vga_port")]
        public short? Vga { get; set; }

        /// <summary>
        /// Количество HDMI-портов.
        /// <para/>
        /// Тип: <see cref="short"/>?.
        /// <para/>
        /// Может быть null, если порт отсутствует.
        /// </summary>
        [Column("hdmi_port")]
        public short? Hdmi { get; set; }

        /// <summary>
        /// Количество DisplayPort-портов.
        /// <para/>
        /// Тип: <see cref="short"/>?.
        /// <para/>
        /// Может быть null, если порт отсутствует.
        /// </summary>
        [Column("display_port")]
        public short? DisplayPort { get; set; }

        /// <summary>
        /// Количество DVI-портов.
        /// <para/>
        /// Тип: <see cref="short"/>?.
        /// <para/>
        /// Может быть null, если порт отсутствует.
        /// </summary>
        [Column("dvi_port")]
        public short? Dvi { get; set; }

        /// <summary>
        /// Общее количество видеопортов.
        /// <para/>
        /// Тип: <see cref="int"/>.
        /// <para/>
        /// Вычисляется как сумма всех портов (VGA, HDMI, DisplayPort, DVI).
        /// <para/>
        /// Не хранится в базе данных.
        /// </summary>
        [NotMapped]
        public int TotalPorts => (Vga ?? 0) + (Hdmi ?? 0) + (DisplayPort ?? 0) + (Dvi ?? 0);

        /// <summary>
        /// Коллекция компонентов GPU, использующих эту видеокарту.
        /// <para/>
        /// Тип: <see cref="ICollection{GPUComponent}"/>.
        /// <para/>
        /// Навигационное свойство для получения всех компонентов, являющихся данным GPU.
        /// </summary>
        [InverseProperty(nameof(GpuComponent.GPUReference))]
        public virtual ICollection<GpuComponent> GPUs { get; set; } = new List<GpuComponent>();
    }
}
