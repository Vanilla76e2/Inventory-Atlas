using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Dictionaries
{
    /// <summary>
    /// DTO для типов мебели.
    /// <para/>
    /// Тип: <see cref="FurnitureTypeDto"/>
    /// <para/>
    /// Наследуется от <see cref="BaseDto"/> и содержит информацию о названии типа мебели и связанных мебельных элементах.
    /// </summary>
    public class FurnitureTypeDto : BaseDto
    {
        /// <summary>
        /// Название типа мебели.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Список идентификаторов мебели данного типа.
        /// <para/>
        /// Тип: <see cref="List{Int32}"/>
        /// <para/>
        /// Может быть <c>null</c> если мебель не указана.
        /// </summary>
        public List<int>? FurnitureIds { get; set; }
    }
}
