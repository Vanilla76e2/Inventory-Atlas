using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Inventory_Atlas.Application.Entities.Base
{
    /// <summary>
    /// Базовая абстрактная сущность с уникальным идентификатором.
    /// <para/>
    /// Все сущности проекта наследуются от этого класса.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Уникальный идентификатор записи.
        /// <para/>
        /// Тип: <see cref="int"/>.
        /// <para/>
        /// Является первичным ключом таблицы.
        /// <para/>
        /// Генерируется базой данных автоматически при добавлении новой записи.
        /// </summary>
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
