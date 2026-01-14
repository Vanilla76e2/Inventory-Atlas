using Inventory_Atlas.Application.Entities.Base;
using Inventory_Atlas.Application.Entities.Inventory;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Application.Entities.Users
{
    /// <summary>
    /// Избранные объекты пользователя.
    /// <para/>
    /// Сущность связывает пользователя с конкретными устройствами, помещёнными в избранное.
    /// </summary>
    [Table("Favourites", Schema = "Users")]
    public class Favourite : BaseEntity
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// <para/>
        /// Тип: <see cref="int"/>.
        /// </summary>
        [Column("user_id")]
        public int UserId { get; set; }

        /// <summary>
        /// Навигационное свойство на пользователя.
        /// <para/>
        /// Тип: <see cref="UserProfile"/>.
        /// <para/>
        /// Не может быть <see langword="null"/>.
        /// </summary>
        [ForeignKey(nameof(UserId))]
        public virtual UserProfile User { get; set; } = null!;

        /// <summary>
        /// Идентификатор объекта, добавленного в избранное.
        /// <para/>
        /// Тип: <see cref="int"/>.
        /// </summary>
        [Column("item_id")]
        public int ItemId { get; set; }

        /// <summary>
        /// Навигационное свойство на устройство.
        /// <para/>
        /// Тип: <see cref="InventoryItem"/>.
        /// <para/>
        /// Не может быть <see langword="null"/>.
        /// </summary>
        [ForeignKey(nameof(ItemId))]
        public virtual InventoryItem Item { get; set; } = null!;

        /// <summary>
        /// Дата добавления в избранное.
        /// <para/>
        /// Тип: <see cref="DateTime"/>
        /// <para/>
        /// По умолчанию <see cref="DateTime.UtcNow"/>
        /// </summary>
        [Column("favourited_at")]
        public DateTime FavouritedAt { get; set; } = DateTime.UtcNow;
    }
}
