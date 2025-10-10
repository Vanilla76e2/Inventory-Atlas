namespace Inventory_Atlas.Core.DTOs.Technics.Components
{
    /// <summary>
    /// DTO для видеокарты как компонента компьютера.
    /// <para/>
    /// Тип: <see cref="GPUComponentDto"/>
    /// <para/>
    /// Наследуется от <see cref="ComputerComponentDto"/> и содержит данные о видеокарте: идентификатор, производителя, модель, объем памяти, тип памяти и количество портов.
    /// </summary>
    public class GPUComponentDto : ComputerComponentDto
    {
        /// <summary>
        /// Идентификатор видеокарты.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int GpuId { get; set; }

        /// <summary>
        /// Производитель видеокарты.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string Vendor { get; set; } = null!;

        /// <summary>
        /// Модель видеокарты.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string Model { get; set; } = null!;

        /// <summary>
        /// Объем видеопамяти в мегабайтах.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int MemorySize { get; set; }

        /// <summary>
        /// Тип видеопамяти.
        /// <para/>
        /// Тип: <see cref="Enums.GpuMemoryType"/>
        /// </summary>
        public Enums.GpuMemoryType MemoryType { get; set; }

        /// <summary>
        /// Количество VGA-портов.
        /// <para/>
        /// Тип: <see langword="short"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public short? Vga { get; set; }

        /// <summary>
        /// Количество HDMI-портов.
        /// <para/>
        /// Тип: <see langword="short"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public short? Hdmi { get; set; }

        /// <summary>
        /// Количество DisplayPort.
        /// <para/>
        /// Тип: <see langword="short"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public short? DisplayPort { get; set; }

        /// <summary>
        /// Количество DVI-портов.
        /// <para/>
        /// Тип: <see langword="short"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public short? Dvi { get; set; }

        /// <summary>
        /// Общее количество портов видеокарты (VGA + HDMI + DisplayPort + DVI).
        /// <para/>
        /// Тип: <see langword="int"/>
        /// <para/>
        /// Рассчитывается автоматически.
        /// </summary>
        public int TotalPorts => (Vga ?? 0) + (Hdmi ?? 0) + (DisplayPort ?? 0) + (Dvi ?? 0);
    }
}
