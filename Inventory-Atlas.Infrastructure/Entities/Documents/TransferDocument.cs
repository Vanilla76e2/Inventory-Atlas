using Inventory_Atlas.Infrastructure.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Documents
{
    /// <summary>
    /// Документ передачи оборудования между сотрудниками.
    /// <para/>
    /// Наследуется от <see cref="DocumentEntity"/> и содержит информацию о сотрудниках-отправителях и получателях, а также о передаваемых позициях.
    /// </summary>
    [Table("TransferDocuments", Schema = "Documents")]
    public class TransferDocument : DocumentEntity
    {
        /// <summary>
        /// Идентификатор сотрудника, передающего оборудование.
        /// <para/>
        /// Тип: <see langword="int"/>.
        /// </summary>
        [Column("from_employee_id")]
        public int FromEmployeeId { get; set; }

        /// <summary>
        /// Навигационное свойство на сотрудника-отправителя.
        /// <para/>
        /// Тип: <see cref="Employees.Employee"/>.
        /// <para/>
        /// Не может быть <see langword="null"/>.
        /// </summary>
        [ForeignKey("FromEmployeeId")]
        public Employees.Employee FromEmployee { get; set; } = null!;

        /// <summary>
        /// Идентификатор сотрудника-получателя оборудования.
        /// <para/>
        /// Тип: <see langword="int"/>.
        /// </summary>
        [Column("to_employee_id")]
        public int ToEmployeeId { get; set; }

        /// <summary>
        /// Навигационное свойство на сотрудника-получателя.
        /// <para/>
        /// Тип: <see cref="Employees.Employee"/>.
        /// <para/>
        /// Не может быть <see langword="null"/>.
        /// </summary>
        [ForeignKey("ToEmployeeId")]
        public Employees.Employee ToEmployee { get; set; } = null!;

        /// <summary>
        /// Коллекция позиций документа передачи.
        /// <para/>
        /// Тип: <see cref="ICollection{TransferDocumentItem}"/>.
        /// <para/>
        /// Инициализируется пустым списком.
        /// </summary>
        [InverseProperty(nameof(TransferDocumentItem.TransferDocument))]
        public virtual ICollection<TransferDocumentItem> Items { get; set; } = new List<TransferDocumentItem>();
    }
}
