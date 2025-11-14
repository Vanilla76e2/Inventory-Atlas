using Inventory_Atlas.Core.DTOs.Common;
using Inventory_Atlas.Core.Enums;

namespace Inventory_Atlas.Core.DTOs.Inventory
{
    /// <summary>
    /// DTO для мебели как инвентарного объекта.
    /// <para/>
    /// Тип: <see cref="FurnitureDto"/>
    /// <para/>
    /// Наследуется от <see cref="InventoryItemDto"/> и содержит информацию о типе мебели, габаритах, весе, ориентации и материалах.
    /// </summary>
    public class FurnitureDto : InventoryItemDto
    {
        /// <summary>
        /// Идентификатор типа мебели.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int FurnitureTypeId { get; set; }

        /// <summary>
        /// Название типа мебели.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string FurnitureTypeName { get; set; } = null!;

        /// <summary>
        /// Габариты мебели (например, длина×ширина×высота).
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? Dimensions { get; set; }

        /// <summary>
        /// Вес мебели в килограммах.
        /// <para/>
        /// Тип: <see langword="double"/>
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Ориентация мебели.
        /// <para/>
        /// Тип: <see cref="FurnitureOrientation"/>
        /// </summary>
        public FurnitureOrientation Orientation { get; set; }

        /// <summary>
        /// Список материалов, из которых состоит мебель.
        /// <para/>
        /// Тип: <see cref="List{FurnitureMaterialAssignmentDto}"/>
        /// <para/>
        /// Может быть <c>null</c> если материалы не указаны.
        /// </summary>
        public List<FurnitureMaterialAssignmentListDto>? Materials { get; set; }
    }

    /// <summary>
    /// DTO для связи мебели с материалами.
    /// <para/>
    /// Тип: <see cref="FurnitureMaterialAssignmentDto"/>
    /// </summary>
    public class FurnitureMaterialAssignmentDto : BaseDto
    {
        /// <summary>
        /// Идентификатор мебели.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int FurnitureId { get; set; }

        /// <summary>
        /// Идентификатор материала.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int MaterialId { get; set; }

        /// <summary>
        /// Название материала.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string MaterialName { get; set; } = null!;
    }

    /// <summary>
    /// Сокращённый DTO для отображения материалов мебели в списках.
    /// </summary>
    public class FurnitureMaterialAssignmentListDto
    {
        /// <summary>
        /// Название материала.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string MaterialName { get; set; } = null!;
    }
}
