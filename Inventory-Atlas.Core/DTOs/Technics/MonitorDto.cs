using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Technics
{
    /// <summary>
    /// DTO для монитора как устройства.
    /// <para/>
    /// Тип: <see cref="MonitorDto"/>
    /// <para/>
    /// Наследуется от <see cref="DeviceDto"/> и содержит характеристики монитора, включая диагональ, разрешение, частоту обновления, тип панели и количество портов.
    /// </summary>
    public class MonitorDto : DeviceDto
    {
        /// <summary>
        /// Диагональ экрана в дюймах.
        /// <para/>
        /// Тип: <see langword="double"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public double? Diagonal { get; set; }

        /// <summary>
        /// Разрешение экрана по вертикали.
        /// <para/>
        /// Тип: <see langword="int"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        public int? ResolutionHeight { get; set; }

        /// <summary>
        /// Разрешение экрана по горизонтали.
        /// <para/>
        /// Тип: <see langword="int"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        public int? ResolutionWidth { get; set; }

        /// <summary>
        /// Частота обновления экрана в Гц.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public int? RefreshRate { get; set; }

        /// <summary>
        /// Тип панели дисплея.
        /// <para/>
        /// Тип: <see cref="DisplayType"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public DisplayType? PanelType { get; set; }

        /// <summary>
        /// Количество VGA портов.
        /// <para/>
        /// Тип: <see langword="short"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public short? Vga { get; set; }

        /// <summary>
        /// Количество HDMI портов.
        /// <para/>
        /// Тип: <see langword="short"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public short? Hdmi { get; set; }

        /// <summary>
        /// Количество DisplayPort портов.
        /// <para/>
        /// Тип: <see langword="short"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public short? DisplayPort { get; set; }

        /// <summary>
        /// Количество DVI портов.
        /// <para/>
        /// Тип: <see langword="short"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public short? Dvi { get; set; }

        /// <summary>
        /// Общее количество портов монитора.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int TotalPorts => (Vga ?? 0) + (Hdmi ?? 0) + (DisplayPort ?? 0) + (Dvi ?? 0);
    }
}
