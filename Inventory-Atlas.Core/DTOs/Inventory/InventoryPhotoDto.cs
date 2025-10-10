using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Inventory
{
    /// <summary>
    /// DTO для фотографии элемента инвентаря.
    /// <para/>
    /// Тип: <see cref="InventoryPhotoDto"/>
    /// </summary>
    public class InventoryPhotoDto : BaseDto
    {
        /// <summary>
        /// Идентификатор элемента инвентаря, к которому принадлежит фотография.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int InventoryItemId { get; set; }

        /// <summary>
        /// Путь к файлу фотографии.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string PhotoPath { get; set; } = null!;

        /// <summary>
        /// Признак основной фотографии элемента.
        /// <para/>
        /// Тип: <see langword="bool"/>
        /// <para/>
        /// По умолчанию <c>false</c>.
        /// </summary>
        public bool IsPrimary { get; set; } = false;
    }
}
