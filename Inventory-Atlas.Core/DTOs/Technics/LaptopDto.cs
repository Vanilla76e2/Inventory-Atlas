using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Technics
{
    /// <summary>
    /// DTO для ноутбука как устройства.
    /// <para/>
    /// Тип: <see cref="LaptopDto"/>
    /// <para/>
    /// Наследуется от <see cref="DeviceDto"/> и содержит информацию о характеристиках ноутбука, включая IP-адрес, диагональ, разрешение, ОС, процессор, RAM, диск и GPU.
    /// </summary>
    public class LaptopDto : DeviceDto
    {
        /// <summary>
        /// IP-адрес ноутбука.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? IpAddress { get; set; }

        /// <summary>
        /// Диагональ экрана в дюймах.
        /// <para/>
        /// Тип: <see langword="double"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public double? Diagonal { get; set; }

        /// <summary>
        /// Разрешение экрана, например "1920x1080".
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? Resolution { get; set; }

        /// <summary>
        /// Операционная система ноутбука.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? OperatingSystem { get; set; }

        /// <summary>
        /// Процессор ноутбука.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? Processor { get; set; }

        /// <summary>
        /// Объем оперативной памяти в ГБ.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public int? RAM { get; set; }

        /// <summary>
        /// Объем накопителя в ГБ.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public int? Drive { get; set; }

        /// <summary>
        /// Идентификатор или объем видеокарты.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public int? GPU { get; set; }
    }
}
