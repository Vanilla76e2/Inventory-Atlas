using Inventory_Atlas.Infrastructure.Entities.Base;
using Inventory_Atlas.Infrastructure.Entities.Employees;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Inventory
{
    /// <summary>
    /// Рабочее место сотрудника.
    /// <para/>
    /// Содержит информацию о названии рабочего места, комментариях, связанном сотруднике
    /// и оборудовании, находящемся на этом месте.
    /// </summary>
    [Table("Workplaces", Schema = "Inventory")]
    public class Workplace : AuditableEntity
    {
        /// <summary>
        /// Название рабочего места.
        /// <para/>
        /// Тип: <see cref="string"/>.
        /// <para/>
        /// Обязательное поле, не может быть null.
        /// </summary>
        [Column("name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Комментарий к рабочему месту.
        /// <para/>
        /// Тип: <see cref="string"/>?.
        /// <para/>
        /// Может содержать дополнительные сведения или примечания.
        /// </summary>
        [Column("comment")]
        public string? Comment { get; set; }

        /// <summary>
        /// Идентификатор сотрудника, которому принадлежит рабочее место.
        /// <para/>
        /// Тип: <see cref="int"/>?.
        /// <para/>
        /// Может быть null, если рабочее место не назначено сотруднику.
        /// </summary>
        [Column("employee_id")]
        public int? EmployeeId { get; set; }

        /// <summary>
        /// Навигационное свойство на сотрудника, которому принадлежит рабочее место.
        /// <para/>
        /// Тип: <see cref="Employee"/>?.
        /// <para/>
        /// Позволяет получить информацию о сотруднике.
        /// </summary>
        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee? Employee { get; set; }

        /// <summary>
        /// Коллекция оборудования, находящегося на рабочем месте.
        /// <para/>
        /// Тип: <see cref="ICollection{WorkplaceEquipment}"/>.
        /// <para/>
        /// Навигационное свойство для получения всех элементов оборудования, связанных с рабочим местом.
        /// </summary>
        [InverseProperty(nameof(WorkplaceEquipment.Workplace))]
        public virtual ICollection<WorkplaceEquipment> WorkplaceEquipments { get; set; } = new List<WorkplaceEquipment>();
    }
}
