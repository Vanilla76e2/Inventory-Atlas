using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Dictionaries
{
    /// <summary>
    /// DTO для материалов мебели.
    /// <para/>
    /// Тип: <see cref="FurnitureMaterialDto"/>
    /// <para/>
    /// Наследуется от <see cref="BaseDto"/> и содержит информацию о названии материала и связанных мебельных элементах.
    /// </summary>
    public class FurnitureMaterialDto : BaseDto
    {
        /// <summary>
        /// Название материала.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string Name { get; set; } = null!;
    }
}
