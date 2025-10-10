using Inventory_Atlas.Core.DTOs.Common;
using Inventory_Atlas.Core.Enums;

namespace Inventory_Atlas.Core.DTOs.Users
{
    /// <summary>
    /// DTO для избранного элемента пользователя.
    /// <para/>
    /// Тип: <see cref="FavouriteDto"/>
    /// <para/>
    /// Наследуется от <see cref="BaseDto"/> и содержит информацию о инвентарном объекте, его состоянии, местоположении и дате добавления в избранное.
    /// </summary>
    public class FavouriteDto : BaseDto
    {
        /// <summary>
        /// Инвентарный номер объекта.
        /// <para/>
        /// Тип: <see langword="long"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public long? InventoryNumber { get; set; }

        /// <summary>
        /// Наименование объекта.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Местоположение объекта.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? Location { get; set; }

        /// <summary>
        /// Статус объекта.
        /// <para/>
        /// Тип: <see cref="InventoryStatus"/>
        /// </summary>
        public InventoryStatus Status { get; set; }

        /// <summary>
        /// Комментарий к объекту.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? Comment { get; set; }

        /// <summary>
        /// Дата и время добавления объекта в избранное.
        /// <para/>
        /// Тип: <see langword="DateTime"/>
        /// </summary>
        public DateTime FavouritedAt { get; set; }
    }
}
