using Inventory_Atlas.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Base
{
    /// <summary>
    /// Абстрактная сущность документа.
    /// <para/>
    /// Наследуется от <see cref="AuditableEntity"/> и содержит базовые сведения о документах:
    /// дата, номер, комментарий и статус документа.
    /// </summary>
    public abstract class DocumentEntity : AuditableEntity
    {
        /// <summary>
        /// Номер документа.
        /// <para/>
        /// Тип: <see langword="int"/>.
        /// <para/>
        /// Не может быть <see langword="null"/>.
        /// </summary>
        [Column("document_number")]
        public int DocumentNumber { get; set; }

        /// <summary>
        /// Дата документа.
        /// <para/>
        /// Тип: <see cref="DateTime"/>.
        /// </summary>
        [Column("document_date")]
        public DateTime DocumentDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Номер или наименование документа.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("document_name")]
        public string? DocumentName { get; set; }

        /// <summary>
        /// Комментарий к документу.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("comment")]
        public string? Comment { get; set; }

        /// <summary>
        /// Статус документа.
        /// <para/>
        /// Тип: <see cref="DocumentStatus"/>.
        /// </summary>
        [Column("document_status")]
        public DocumentStatus DocumentStatus { get; set; }
    }
}
