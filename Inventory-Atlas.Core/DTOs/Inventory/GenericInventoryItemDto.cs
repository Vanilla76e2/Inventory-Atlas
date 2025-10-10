using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Inventory
{
    /// <summary>
    /// DTO для универсального элемента инвентаря.
    /// <para/>
    /// Тип: <see cref="GenericInventoryItemDto"/>
    /// <para/>
    /// Наследуется от <see cref="InventoryItemDto"/> и содержит информацию о категории и свойствах.
    /// </summary>
    public class GenericInventoryItemDto : InventoryItemDto
    {
        /// <summary>
        /// Идентификатор категории элемента.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Название категории элемента.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string CategoryName { get; set; } = null!;

        /// <summary>
        /// Свойства элемента в формате JSON.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// По умолчанию пустой объект <c>"{}"</c>.
        /// </summary>
        public string Properties { get; set; } = "{}";
    }

    /// <summary>
    /// DTO для категории элементов инвентаря.
    /// <para/>
    /// Тип: <see cref="InventoryCategoryDto"/>
    /// </summary>
    public class InventoryCategoryDto : BaseDto
    {
        /// <summary>
        /// Название категории.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Описание категории.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string Description { get; set; } = null!;

        /// <summary>
        /// Пользовательские поля категории в формате JSON.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// По умолчанию пустой массив <c>"[]"</c>.
        /// </summary>
        public string CustomFields { get; set; } = "[]";

        /// <summary>
        /// Идентификаторы элементов инвентаря, принадлежащих категории.
        /// <para/>
        /// Тип: <see cref="List{Int32}"/>
        /// <para/>
        /// Может быть <c>null</c> если элементы не указаны.
        /// </summary>
        public List<int>? ItemIds { get; set; }
    }
}
