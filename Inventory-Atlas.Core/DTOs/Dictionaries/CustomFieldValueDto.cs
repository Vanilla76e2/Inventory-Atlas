using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Dictionaries
{
    /// <summary>
    /// DTO для значения пользовательских полей.
    /// <para/>
    /// Наследуется от <see cref="BaseDto"/>.
    /// </summary>
    public class CustomFieldValueDto : BaseDto
    {
        /// <summary>
        /// Идентификатор инвентарного объекта.
        /// <para/>
        /// Тип: <see langword="int"/>.
        /// </summary>
        public int InventoryItemId { get; set; }

        /// <summary>
        /// Наименование инвентарного объекта.
        /// <para/>
        /// Тип: <see langword="string"/>.
        /// </summary>
        public string InventoryItemName { get; set; } = null!;

        /// <summary>
        /// Идентификатор пользовательского поля.
        /// <para/>
        /// Тип: <see langword="int"/>.
        /// </summary>
        public int FieldId { get; set; }

        /// <summary>
        /// Наименование пользовательского поля.
        /// <para/>
        /// Тип: <see langword="string"/>.
        /// </summary>
        public string FieldName { get; set; } = null!;

        /// <summary>
        /// Значение пользовательского поля.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        public string? Value { get; set; }
    }
}
