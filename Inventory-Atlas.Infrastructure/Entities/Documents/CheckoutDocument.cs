using Inventory_Atlas.Infrastructure.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Documents
{
    /// <summary>
    /// Документ выдачи оборудования сотруднику.
    /// <para/>
    /// Наследуется от <see cref="DocumentEntity"/> и содержит информацию о сотруднике и выданных позициях.
    /// </summary>
    [Table("CheckoutDocuments", Schema = "Documents")]
    public class CheckoutDocument : DocumentEntity
    {
        /// <summary>
        /// Идентификатор сотрудника, которому выдано оборудование.
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
        /// Коллекция позиций документа выдачи.
        /// <para/>
        /// Тип: <see cref="ICollection{CheckoutDocumentItem}"/>.
        /// <para/>
        /// Инициализируется пустым списком.
        /// </summary>
        [InverseProperty(nameof(CheckoutDocumentItem.Document))]
        public ICollection<CheckoutDocumentItem> Items = new List<CheckoutDocumentItem>();
    }
}
