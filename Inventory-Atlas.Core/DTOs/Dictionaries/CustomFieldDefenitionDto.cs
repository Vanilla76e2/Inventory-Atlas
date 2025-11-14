using Inventory_Atlas.Core.DTOs.Common;
using Inventory_Atlas.Core.Enums;

namespace Inventory_Atlas.Core.DTOs.Dictionaries
{
    /// <summary>
    /// DTO для свойств пользовательского поля.
    /// <para/>
    /// Наследуется от <see cref="BaseDto"/>.
    /// </summary>
    public class CustomFieldDefenitionDto : BaseDto
    {
        /// <summary>
        /// Идентификатор категории инвентарного объекта.
        /// <para/>
        /// Тип: <see langword="int"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        public int? CategoryId { get; set; }

        /// <summary>
        /// Наименование категории инвентарного объекта.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        public string? CategoryName { get; set; }

        /// <summary>
        /// Наименование пользовательского поля.
        /// <para/>
        /// Тип: <see langword="string"/>.
        /// </summary>
        public string FieldName { get; set; } = null!;

        /// <summary>
        /// Тип данных пользовательского поля.
        /// <para/>
        /// Тип: <see cref="DataTypeEnum"/>.
        /// </summary>
        public DataTypeEnum DataType { get; set; }

        /// <summary>
        /// Флаг определяющий обязательность пользовательского поля.
        /// <para/>
        /// Тип: <see langword="bool"/>.
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// Порядок расположения пользовательских полей.
        /// <para/>
        /// Тип: <see langword="int"/>.
        /// </summary>
        public int Order { get; set; }
    }
}
