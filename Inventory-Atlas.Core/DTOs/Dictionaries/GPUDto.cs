using Inventory_Atlas.Core.DTOs.Common;
using Inventory_Atlas.Core.Enums;

namespace Inventory_Atlas.Core.DTOs.Dictionaries
{
    /// <summary>
    /// DTO для графических процессоров (GPU).
    /// <para/>
    /// Тип: <see cref="GPUDto"/>
    /// <para/>
    /// Наследуется от <see cref="BaseDto"/> и содержит характеристики видеокарты, включая память и типы портов.
    /// </summary>
    public class GPUDto : BaseDto
    {
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
        /// Объём видеопамяти в мегабайтах.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int MemorySize { get; set; }

        /// <summary>
        /// Тип видеопамяти.
        /// <para/>
        /// Тип: <see cref="GpuMemoryType"/>
        /// </summary>
        public GpuMemoryType MemoryType { get; set; }

        /// <summary>
        /// Количество портов VGA.
        /// <para/>
        /// Тип: <see langword="short"/>
        /// <para/>
        /// Может быть <c>null</c> если порт отсутствует.
        /// </summary>
        public short? Vga { get; set; }

        /// <summary>
        /// Количество портов HDMI.
        /// <para/>
        /// Тип: <see langword="short"/>
        /// <para/>
        /// Может быть <c>null</c> если порт отсутствует.
        /// </summary>
        public short? Hdmi { get; set; }

        /// <summary>
        /// Количество портов DisplayPort.
        /// <para/>
        /// Тип: <see langword="short"/>
        /// <para/>
        /// Может быть <c>null</c> если порт отсутствует.
        /// </summary>
        public short? DisplayPort { get; set; }

        /// <summary>
        /// Количество портов DVI.
        /// <para/>
        /// Тип: <see langword="short"/>
        /// <para/>
        /// Может быть <c>null</c> если порт отсутствует.
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

        /// <summary>
        /// Список идентификаторов компонентов, к которым привязана видеокарта.
        /// <para/>
        /// Тип: <see cref="List{Int32}"/>
        /// <para/>
        /// Может быть <c>null</c> если компоненты не указаны.
        /// </summary>
        public List<int>? ComponentIds { get; set; }
    }
}
