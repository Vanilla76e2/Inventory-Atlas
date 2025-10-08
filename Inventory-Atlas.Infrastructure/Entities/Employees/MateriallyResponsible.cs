using Inventory_Atlas.Infrastructure.Entities.Base;
using Inventory_Atlas.Infrastructure.Entities.Inventory;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Employees
{
    /// <summary>
    /// Материальная ответственность.
    /// <para/>
    /// Содержит ссылку на сотрудника, отображаемое имя, комментарий и коллекцию инвентарных объектов, за которые он отвечает.
    /// </summary>
    [Table("MaterialResponsibles", Schema = "Employees")]
    public class MateriallyResponsible : BaseEntity
    {
        /// <summary>
        /// Идентификатор сотрудника.
        /// <para/>
        /// Тип: <see cref="int"/>.
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
        public virtual Employees.Employee Employee { get; set; } = new();

        /// <summary>
        /// Отображаемое имя ответственного.
        /// <para/>
        /// Тип: <see langword="string"/>.
        /// <para/>
        /// Не может быть <see langword="null"/>.
        /// </summary>
        [Column("display_name")]
        public string DisplayName { get; set; } = null!;

        /// <summary>
        /// Комментарий.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("comment")]
        public string? Comment { get; set; }

        /// <summary>
        /// Коллекция инвентарных объектов, за которые отвечает данный сотрудник.
        /// <para/>
        /// Тип: <see cref="ICollection{InventoryItem}"/>.
        /// <para/>
        /// Не может быть <see langword="null"/>.
        /// </summary>
        [InverseProperty(nameof(InventoryItem.Responsible))]
        public ICollection<InventoryItem> Items { get; set; } = new List<InventoryItem>();
    }
}
