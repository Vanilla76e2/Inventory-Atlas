using Inventory_Atlas.Core.DTOs.Common;
using Inventory_Atlas.Core.Enums;

namespace Inventory_Atlas.Core.DTOs.Dictionaries
{
    /// <summary>
    /// DTO для материнских плат (Motherboard).
    /// <para/>
    /// Тип: <see cref="MoBoDto"/>
    /// <para/>
    /// Наследуется от <see cref="BaseDto"/> и содержит характеристики материнской платы.
    /// </summary>
    public class MoBoDto : BaseDto
    {
        /// <summary>
        /// Производитель материнской платы.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string Vendor { get; set; } = null!;

        /// <summary>
        /// Модель материнской платы.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string Model { get; set; } = null!;

        /// <summary>
        /// Тип сокета процессора.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c> если не указан.
        /// </summary>
        public string? Socket { get; set; }

        /// <summary>
        /// Чипсет материнской платы.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c> если не указан.
        /// </summary>
        public string? Chipset { get; set; }

        /// <summary>
        /// Форм-фактор материнской платы.
        /// <para/>
        /// Тип: <see cref="MoBoFormFactor"/>
        /// </summary>
        public MoBoFormFactor FormFactor { get; set; }

        /// <summary>
        /// Количество слотов для оперативной памяти.
        /// <para/>
        /// Тип: <see langword="short"/>
        /// <para/>
        /// Может быть <c>null</c> если не указано.
        /// </summary>
        public short? RamSlots { get; set; }

        /// <summary>
        /// Количество слотов PCIe.
        /// <para/>
        /// Тип: <see langword="short"/>
        /// <para/>
        /// Может быть <c>null</c> если не указано.
        /// </summary>
        public short? PcieSlots { get; set; }

        /// <summary>
        /// Количество слотов M.2.
        /// <para/>
        /// Тип: <see langword="short"/>
        /// <para/>
        /// Может быть <c>null</c> если не указано.
        /// </summary>
        public short? M2Slots { get; set; }
    }
}
