using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Consumables
{
    /// <summary>
    /// DTO для картриджей принтера с информацией для аудита.
    /// <para/>
    /// Тип: <see cref="PrinterCartridgeDto"/>
    /// <para/>
    /// Наследуется от <see cref="AuditableDto"/>, содержит название, модель и количество картриджей.
    /// </summary>
    public class PrinterCartridgeDto : AuditableDto
    {
        /// <summary>
        /// Название картриджа.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Модель картриджа.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string Model { get; set; } = null!;

        /// <summary>
        /// Количество картриджей на складе.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int Quantity { get; set; }
    }
}
