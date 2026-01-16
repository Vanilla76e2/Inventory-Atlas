using Inventory_Atlas.Infrastructure.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Documents
{
    /// <summary>
    /// Документ возврата оборудования от сотрудника.
    /// <para/>
    /// Наследуется от <see cref="DocumentEntity"/> и содержит информацию о сотруднике и возвращённых позициях.
    /// </summary>
    [Table("ReturnDocuments", Schema = "Documents")]
    public class ReturnDocument : DocumentEntity
    {
        /// <summary>
        /// Идентификатор сотрудника, возвращающего оборудование.
        /// <para/>
        /// Тип: <see langword="int"/>.
        /// </summary>
        [Column("employee_id")]
        public int EmployeeId { get; set; }

        /// <summary>
        /// Навигационное свойство на сотрудника.
        /// <para/>
        /// Тип: <see cref="Employees.Employee"/>.
        /// <para/>
        /// Не может быть <see langword="null"/>.
        /// </summary>
        [ForeignKey(nameof(EmployeeId))]
        public Employees.Employee Employee { get; set; } = null!;

        /// <summary>
        /// Коллекция позиций документа возврата.
        /// <para/>
        /// Тип: <see cref="ICollection{ReturnDocumentItem}"/>.
        /// <para/>
        /// Инициализируется пустым списком.
        /// </summary>
        [InverseProperty(nameof(ReturnDocumentItem.Document))]
        public ICollection<ReturnDocumentItem> Items = new List<ReturnDocumentItem>();
    }
}
