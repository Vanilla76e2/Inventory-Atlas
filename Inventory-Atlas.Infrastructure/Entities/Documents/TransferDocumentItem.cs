using Inventory_Atlas.Infrastructure.Entities.Base;
using Inventory_Atlas.Infrastructure.Entities.Inventory;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Documents
{
    /// <summary>
    /// Позиция документа передачи оборудования.
    /// <para/>
    /// Связывает конкретный документ <see cref="TransferDocument"/> с конкретным предметом <see cref="InventoryItem"/>.
    /// </summary>
    [Table("TransferTableItems", Schema = "Documents")]
    public class TransferDocumentItem : BaseEntity
    {
        /// <summary>
        /// Идентификатор документа передачи.
        /// <para/>
        /// Тип: <see langword="int"/>.
        /// </summary>
        [Column("document_id")]
        public int DocumentId { get; set; }

        /// <summary>
        /// Навигационное свойство на документ передачи.
        /// <para/>
        /// Тип: <see cref="TransferDocument"/>.
        /// <para/>
        /// Не может быть <see langword="null"/>.
        /// </summary>
        [ForeignKey("DocumentId")]
        public virtual TransferDocument TransferDocument { get; set; } = new TransferDocument();

        /// <summary>
        /// Идентификатор предмета инвентаря.
        /// <para/>
        /// Тип: <see langword="int"/>.
        /// </summary>
        [Column("item_id")]
        public int ItemId { get; set; }

        /// <summary>
        /// Навигационное свойство на предмет инвентаря.
        /// <para/>
        /// Тип: <see cref="InventoryItem"/>.
        /// <para/>
        /// Не может быть <see langword="null"/>.
        /// </summary>
        [ForeignKey(nameof(ItemId))]
        public virtual InventoryItem Item { get; set; } = null!;
    }
}
