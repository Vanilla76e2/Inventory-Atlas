using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Application.Entities.Base
{
    /// <summary>
    /// Абстрактная сущность с поддержкой мягкого удаления.
    /// <para/>
    /// Наследуется от <see cref="AuditableEntity"/> и добавляет свойства для пометки записи как удалённой
    /// без физического удаления из базы данных.
    /// </summary>
    public abstract class SoftDeletable : AuditableEntity
    {
        /// <summary>
        /// Флаг мягкого удаления записи.
        /// <para/>
        /// Тип: <see cref="bool"/>.
        /// <para/>
        /// По умолчанию false. Если true, запись считается удалённой и обычно исключается из выборок.
        /// </summary>
        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// Время мягкого удаления записи.
        /// <para/>
        /// Тип: <see cref="DateTime"/>?.
        /// <para/>
        /// Указывается в UTC. Может быть null, если запись ещё не удалена.
        /// </summary>
        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}
