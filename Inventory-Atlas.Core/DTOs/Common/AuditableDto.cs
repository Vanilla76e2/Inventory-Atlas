namespace Inventory_Atlas.Core.DTOs.Common
{
    /// <summary>
    /// DTO с базовой информацией для аудита сущностей.
    /// <para/>
    /// Тип: <see cref="AuditableDto"/>
    /// <para/>
    /// Содержит данные о времени создания и последнего обновления.
    /// </summary>
    public class AuditableDto : BaseDto
    {
        /// <summary>
        /// Дата и время создания сущности.
        /// <para/>
        /// Тип: <see langword="DateTime"/>
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Дата и время последнего обновления сущности.
        /// <para/>
        /// Тип: <see langword="DateTime"/>
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}
