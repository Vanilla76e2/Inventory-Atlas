using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Technics
{
    /// <summary>
    /// Сущность монитора.
    /// <para/>
    /// Наследуется от <see cref="Equipment"/> и содержит характеристики устройства:
    /// модель, диагональ, разрешение, частоту обновления, тип панели и количество видеопортов.
    /// </summary>
    [Table("Monitors", Schema = "Technics")]
    public class Monitor : Equipment
    {
        /// <summary>
        /// Модель монитора.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>. Ограничение длины 255 символов.
        /// </summary>
        [Column("model")]
        [StringLength(255)]
        public string Model { get; set; } = null!;

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
        /// Частота обновления экрана в герцах.
        /// <para/>
        /// Тип: <see langword="int"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("refresh_rate")]
        public int? RefreshRate { get; set; } // in Hz

        /// <summary>
        /// Тип панели (например, IPS, TN, VA).
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("panel_type")]
        [StringLength(50)]
        public string? PanelType { get; set; } // e.g., IPS, TN, VA

        /// <summary>
        /// Количество VGA портов.
        /// <para/>
        /// Тип: <see langword="short"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("vga_port")]
        public short? Vga { get; set; }

        /// <summary>
        /// Количество HDMI портов.
        /// <para/>
        /// Тип: <see langword="short"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("hdmi_port")]
        public short? Hdmi { get; set; }

        /// <summary>
        /// Количество DisplayPort портов.
        /// <para/>
        /// Тип: <see langword="short"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("display_port")]
        public short? DisplayPort { get; set; }

        /// <summary>
        /// Количество DVI портов.
        /// <para/>
        /// Тип: <see langword="short"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
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
    }
}
