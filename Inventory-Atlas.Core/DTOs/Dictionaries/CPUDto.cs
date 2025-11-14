using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Dictionaries
{
    /// <summary>
    /// DTO для центрального процессора (CPU).
    /// <para/>
    /// Тип: <see cref="CPUDto"/>
    /// <para/>
    /// Наследуется от <see cref="BaseDto"/> и содержит информацию о характеристиках процессора.
    /// </summary>
    public class CPUDto : BaseDto
    {
        /// <summary>
        /// Название процессора.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string Model { get; set; } = null!;

        /// <summary>
        /// Производитель процессора.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? Vendor { get; set; }

        /// <summary>
        /// Количество ядер процессора.
        /// <para/>
        /// Тип: <see langword="short"/>
        /// <para/>
        /// Может быть <c>null</c> если значение неизвестно.
        /// </summary>
        public short? CoreCount { get; set; }

        /// <summary>
        /// Количество потоков процессора.
        /// <para/>
        /// Тип: <see langword="short"/>
        /// <para/>
        /// Может быть <c>null</c> если значение неизвестно.
        /// </summary>
        public short? ThreadCount { get; set; }

        /// <summary>
        /// Тактовая частота процессора в ГГц.
        /// <para/>
        /// Тип: <see langword="double"/>
        /// <para/>
        /// Может быть <c>null</c> если значение неизвестно.
        /// </summary>
        public double? Clock { get; set; }

        /// <summary>
        /// Тип сокета процессора.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c> если сокет не указан.
        /// </summary>
        public string? Socket { get; set; }
    }
}
