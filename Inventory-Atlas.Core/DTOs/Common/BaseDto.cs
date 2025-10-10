namespace Inventory_Atlas.Core.DTOs.Common
{
    /// <summary>
    /// Базовый DTO с идентификатором сущности.
    /// <para/>
    /// Тип: <see cref="BaseDto"/>
    /// <para/>
    /// Используется в качестве родительского класса для всех DTO, имеющих уникальный идентификатор.
    /// </summary>
    public class BaseDto
    {
        /// <summary>
        /// Уникальный идентификатор сущности.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int Id { get; set; }
    }
}
