using Inventory_Atlas.Infrastructure.Entities.Base;
using Inventory_Atlas.Infrastructure.Entities.Inventory;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Documents
{
    /// <summary>
    /// Позиция документа списания оборудования.
    /// <para/>
    /// Связывает конкретный документ <see cref="WriteOffDocument"/> с конкретным предметом <see cref="InventoryItem"/>.
    /// </summary>
    [Table("WriteOffDocumentItems", Schema = "Documents")]
    public class WriteOffDocumentItem : BaseEntity
    {
        /// <summary>
        /// Идентификатор документа списания.
        /// <para/>
        /// Тип: <see langword="int"/>.
        /// </summary>
        [Column("document_id")]
        public int DocumentId { get; set; }

        /// <summary>
        /// Навигационное свойство на документ списания.
        /// <para/>
        /// Тип: <see cref="WriteOffDocument"/>.
        /// <para/>
        /// Не может быть <see langword="null"/>.
        /// </summary>
        [ForeignKey("DocumentId")]
        public WriteOffDocument Document { get; set; } = null!;

        /// <summary>
        /// Идентификатор предмета инвентаря.
        /// <para/>
        /// Тип: <see langword="int"/>.
        /// </summary>
        [Column("items_id")]
        public int ItemId { get; set; }

        /// <summary>
        /// Навигационное свойство на предмет инвентаря.
        /// <para/>
        /// Тип: <see cref="InventoryItem"/>.
        /// <para/>
        /// Не может быть <see langword="null"/>.
        /// </summary>
        [ForeignKey("WriteOffItems")]
        public InventoryItem Item { get; set; } = null!;
    }
}
