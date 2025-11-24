namespace Inventory_Atlas.Core.Models
{
    public class LogDetails<T>
    {
        /// <summary>
        /// Название сущности.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// </summary>
        public string EntityName { get; set; } = nameof(T);

        /// <summary>
        /// Идентификатор сущности.
        /// <para/>
        /// <see langword="int"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        public int? EntityId { get; set; }

        /// <summary>
        /// Старое состояние объекта.
        /// <para/>
        /// <see cref="T"/>?.
        /// <para/>
        /// Может быть null <see langword="null"/>.
        /// </summary>
        public Dictionary<string, object>? Old { get; set; }

        /// <summary>
        /// Новое состояние объекта.
        /// <para/>
        /// Тип: <see cref="T"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        public Dictionary<string, object>? New { get; set; }
        
        /// <summary>
        /// Дополнительные данные.
        /// <para/>
        /// Тип: <see cref="object"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        public object? Extra { get; set; }
    }
}
