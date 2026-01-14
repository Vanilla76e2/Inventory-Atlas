using Inventory_Atlas.Application.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Application.Entities.Employees
{
    /// <summary>
    /// Отдел компании.
    /// <para/>
    /// Содержит информацию о названии отдела, комментариях и связанных сотрудниках.
    /// </summary>
    [Table("Departments", Schema = "Employees")]
    public class Department : AuditableEntity
    {
        /// <summary>
        /// Название отдела.
        /// <para/>
        /// Тип: <see cref="string"/>.
        /// <para/>
        /// Обязательное поле, не может быть null.
        /// </summary>
        [Column("name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Комментарий к отделу.
        /// <para/>
        /// Тип: <see cref="string"/>?.
        /// <para/>
        /// Может содержать дополнительные сведения или примечания.
        /// </summary>
        [Column("comment")]
        public string? Comment { get; set; }

        /// <summary>
        /// Коллекция сотрудников, работающих в данном отделе.
        /// <para/>
        /// Тип: <see cref="ICollection{Employee}"/>.
        /// <para/>
        /// Навигационное свойство для доступа к связанным сотрудникам.
        /// </summary>
        [InverseProperty(nameof(Employee.Department))]
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
