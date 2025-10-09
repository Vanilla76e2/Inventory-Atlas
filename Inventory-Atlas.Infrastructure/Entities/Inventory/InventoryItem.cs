using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Infrastructure.Entities.Base;
using Inventory_Atlas.Infrastructure.Entities.Documents;
using Inventory_Atlas.Infrastructure.Entities.Employees;
using Inventory_Atlas.Infrastructure.Entities.Services;
using Inventory_Atlas.Infrastructure.Entities.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Inventory
{
    /// <summary>
    /// Базовый инвентарный объект.
    /// <para/>
    /// Содержит общие свойства всех объектов инвентаря и связь с документами передачи.
    /// </summary>
    [Table("InventoryItems", Schema = "Inventory")]
    public class InventoryItem : SoftDeletable
    {
        /// <summary>
        /// Название объекта.
        /// <para/>
        /// Тип: <see cref="string"/>.
        /// <para/>
        /// Обязательное поле, не может быть null.
        /// </summary>
        [Column("name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Инвентарный номер объекта.
        /// <para/>
        /// Тип: <see cref="long"/>?.
        /// <para/>
        /// Может быть null, если номер ещё не присвоен.
        /// </summary>
        [Column("inventory_number")]
        public long? InventoryNumber { get; set; }

        /// <summary>
        /// Реестровый номер номер объекта.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("registry_number")]
        public string? RegistryNumber { get; set; }

        /// <summary>
        /// Идентификатор сотрудника, ответственного за объект.
        /// <para/>
        /// Тип: <see cref="int"/>?.
        /// <para/>
        /// Может быть null, если ответственный сотрудник не назначен.
        /// </summary>
        [Column("responsible_id")]
        public int? ResponsibleId { get; set; }

        /// <summary>
        /// Навигационное свойство на сотрудника, ответственного за объект.
        /// <para/>
        /// Тип: <see cref="MateriallyResponsible"/>?.
        /// <para/>
        /// Используется для доступа к дополнительной информации о сотруднике.
        /// </summary>
        [ForeignKey(nameof(ResponsibleId))]
        public virtual MateriallyResponsible? Responsible { get; set; }

        /// <summary>
        /// Местоположение объекта.
        /// <para/>
        /// Тип: <see cref="string"/>?.
        /// <para/>
        /// Может быть null, если местоположение не указано.
        /// </summary>
        [Column("location")]
        public string? Location { get; set; }

        /// <summary>
        /// Статус Объекта.
        /// <para/>
        /// Тип: <see cref="InventoryStatus"/>.
        /// <para/>
        /// Указывает текущее состояние объекта (например, в эксплуатации, списано и т.д.).
        /// </summary>
        [Column("status_id")]
        public InventoryStatus StatusId { get; set; }

        /// <summary>
        /// Комментарий по объект.
        /// <para/>
        /// Тип: <see cref="string"/>?.
        /// <para/>
        /// Может содержать дополнительные сведения, примечания или инструкции.
        /// </summary>
        [Column("comment")]
        public string? Comment { get; set; }

        /// <summary>
        /// Коллекция фотографий объекта.
        /// <para/>
        /// Тип: <see cref="ICollection{T}"/> с элементами <see cref="InventoryPhoto"/>.
        /// <para/>
        /// Не может быть <see langword="null"/> (инициализируется пустым списком).
        /// </summary>
        [InverseProperty(nameof(InventoryPhoto.InventoryItem))]
        public virtual ICollection<InventoryPhoto> InventoryItemPhotos { get; set; } = new List<InventoryPhoto>();

        /// <summary>
        /// Коллекция элементов документов передачи, связанных с этим инвентарным объектом.
        /// <para/>
        /// Тип: <see cref="ICollection{TransferDocumentItem}"/>.
        /// <para/>
        /// Позволяет получить все записи документов передачи, в которых участвует данный объект.
        /// </summary>
        [InverseProperty(nameof(TransferDocumentItem.Item))]
        public virtual ICollection<TransferDocumentItem> TransferDocumentItems { get; set; } = new List<TransferDocumentItem>();

        /// <summary>
        /// Коллекция избранных элементов, связанных с этим объектом.
        /// <para/>
        /// Тип: <see cref="ICollection{Favourite}"/>.
        /// <para/>
        /// Используется для навигации к записям, которые пользователь отметил как избранные.
        /// </summary>
        [InverseProperty(nameof(Favourite.Item))]
        public virtual ICollection<Favourite> Favourites { get; set; } = new List<Favourite>();

        [InverseProperty(nameof(CheckoutDocumentItem.Item))]
        public virtual ICollection<CheckoutDocumentItem> CheckoutDocumentItems { get; set; } = new List<CheckoutDocumentItem>();

        [InverseProperty(nameof(ReturnDocumentItem.Item))]
        public virtual ICollection<ReturnDocumentItem> ReturnDocumentItems { get; set; } = new List<ReturnDocumentItem>();

        [InverseProperty(nameof(WriteOffDocumentItem.Item))]
        public virtual ICollection<WriteOffDocumentItem> WriteOffDocumentItems { get; set; } = new List<WriteOffDocumentItem>();
    }
}
