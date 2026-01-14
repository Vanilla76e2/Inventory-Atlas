using Inventory_Atlas.Application.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Application.Entities.Documents
{
    /// <summary>
    /// Документ списания оборудования.
    /// <para/>
    /// Наследуется от <see cref="DocumentEntity"/> и содержит информацию о причине списания и списываемых позициях.
    /// </summary>
    [Table("WriteOffDocuments", Schema = "Documents")]
    public class WriteOffDocument : DocumentEntity
    {
        /// <summary>
        /// Причина списания оборудования.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("reason")]
        public string? Reason { get; set; }

        /// <summary>
        /// Коллекция позиций документа списания.
        /// <para/>
        /// Тип: <see cref="ICollection{WriteOffDocumentItem}"/>.
        /// <para/>
        /// Инициализируется пустым списком.
        /// </summary>
        [InverseProperty(nameof(WriteOffDocumentItem.Document))]
        public ICollection<WriteOffDocumentItem> Items { get; set; } = new List<WriteOffDocumentItem>();
    }
}
