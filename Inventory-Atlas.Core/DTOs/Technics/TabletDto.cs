using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Technics
{
    /// <summary>
    /// DTO для планшета как устройства.
    /// <para/>
    /// Тип: <see cref="TabletDto"/>
    /// <para/>
    /// Наследуется от <see cref="DeviceDto"/> и содержит информацию об операционной системе, диагонали экрана, оперативной памяти и объёме накопителя.
    /// </summary>
    public class TabletDto : DeviceDto
    {
        /// <summary>
        /// Операционная система планшета.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? OperatingSystem { get; set; }

        /// <summary>
        /// Диагональ экрана в дюймах.
        /// <para/>
        /// Тип: <see langword="float"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public float? Diagonal { get; set; }

        /// <summary>
        /// Объём оперативной памяти в ГБ.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public int? RAM { get; set; }

        /// <summary>
        /// Объём встроенного накопителя в ГБ.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public int? Drive { get; set; }
    }
}
