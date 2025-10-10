namespace Inventory_Atlas.Core.DTOs.Common
{
    /// <summary>
    /// DTO с поддержкой мягкого удаления.
    /// <para/>
    /// Тип: <see cref="SoftDeletableDto"/>
    /// <para/>
    /// Наследуется от <see cref="AuditableDto"/> и добавляет информацию о статусе удаления.
    /// </summary>
    public class SoftDeletableDto : AuditableDto
    {
        /// <summary>
        /// Признак того, что сущность помечена как удалённая.
        /// <para/>
        /// Тип: <see langword="bool"/>
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Дата и время мягкого удаления сущности.
        /// <para/>
        /// Тип: <see langword="DateTime"/>
        /// <para/>
        /// Может быть <c>null</c> если сущность ещё не удалена.
        /// </summary>
        public DateTime? DeletedAt { get; set; }
    }
}
