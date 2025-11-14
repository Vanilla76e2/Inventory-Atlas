using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Dictionaries
{
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
        /// Тип: Коллекция <see langword="int"/>
        /// <para/>
        /// Может быть <see langword="null"/> если элементы не указаны.
        /// </summary>
        public List<int> ItemIds { get; set; } = new();
    }
}
