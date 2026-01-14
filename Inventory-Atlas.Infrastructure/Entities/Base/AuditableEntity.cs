using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Application.Entities.Base
{
    /// <summary>
    /// Абстрактная сущность, поддерживающая аудит изменений.
    /// <para/>
    /// Содержит информацию о времени создания и последнего обновления записи.
    /// Наследуется всеми сущностями, для которых требуется аудит.
    /// </summary>
    public abstract class AuditableEntity : BaseEntity
    {
        /// <summary>
        /// Время создания записи.
        /// <para/>
        /// Тип: <see cref="DateTime"/>.
        /// <para/>
        /// Указывается в UTC. Должно устанавливаться при создании сущности.
        /// </summary>
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Время последнего обновления записи.
        /// <para/>
        /// Тип: <see cref="DateTime"/>.
        /// <para/>
        /// Указывается в UTC. Обновляется при каждом изменении сущности.
        /// </summary>
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
