using Inventory_Atlas.Application.Entities.Base;
using Inventory_Atlas.Application.Entities.Inventory;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Application.Entities.Documents
{
    /// <summary>
    /// Позиция документа возврата оборудования.
    /// <para/>
    /// Связывает конкретный документ <see cref="ReturnDocument"/> с конкретным предметом <see cref="InventoryItem"/>.
    /// </summary>
    [Table("ReturnDocumentItems", Schema = "Documents")]
    public class ReturnDocumentItem : BaseEntity
    {
        /// <summary>
        /// Идентификатор документа возврата.
        /// <para/>
        /// Тип: <see langword="int"/>.
        /// </summary>
        [Column("document_id")]
        public int DocumentId { get; set; }

        /// <summary>
        /// Навигационное свойство на документ возврата.
        /// <para/>
        /// Тип: <see cref="ReturnDocument"/>.
        /// <para/>
        /// Не может быть <see langword="null"/>.
        /// </summary>
        [ForeignKey(nameof(DocumentId))]
        public ReturnDocument Document { get; set; } = null!;

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
        public InventoryItem Item { get; set; } = null!;
    }
}
