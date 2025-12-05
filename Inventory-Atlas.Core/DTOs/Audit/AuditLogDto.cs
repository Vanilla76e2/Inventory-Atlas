namespace Inventory_Atlas.Core.DTOs.Audit
{
    /// <summary>
    /// Изменение в столбце сущности.
    /// </summary>
    public class AuditEntryChange
    {
        /// <summary>
        /// Имя столбца.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// </summary>
        public string ColumnName { get; set; } = null!;

        /// <summary>
        /// Старое значение столбца.
        /// <para/>
        /// Тип: <see langword="object"/>
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        public object? OriginalValue { get; set; }

        /// <summary>
        /// Новое значение столбца.
        /// <para/>
        /// Тип: <see langword="object"/>
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        public object? NewValue { get; set; }
    }

    /// <summary>
    /// Действие с сущностью в EF.
    /// <para/>
    /// </summary>
    public class AuditEntry
    {
        /// <summary>
        /// Имя сущности.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Имя таблицы в БД.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// </summary>
        public string Table { get; set; } = null!;

        /// <summary>
        /// Тип действия: Insert, Update, Delete.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// </summary>
        public string Action { get; set; } = null!;

        /// <summary>
        /// Валидность записи.
        /// <para/>
        /// Тип: <see langword="bool"/>
        /// </summary>
        public bool Valid { get; set; }

        /// <summary>
        /// Текущие значения столбцов сущности.
        /// <para/>
        /// Тип: <see cref="Dictionary{String,Object}"/>
        /// </summary>
        public Dictionary<string, object?> ColumnValues { get; set; } = new();

        /// <summary>
        /// Изменения столбцов в записи.
        /// <para/>
        /// Тип: <see cref="List{AuditEntryChange}"/>
        /// </summary>
        public List<AuditEntryChange> Changes { get; set; } = new();

        /// <summary>
        /// Значения первичного ключа.
        /// <para/>
        /// Тип: <see cref="Dictionary{String,Object}"/>
        /// </summary>
        public Dictionary<string, object?> PrimaryKey { get; set; } = new();
    }

    /// <summary>
    /// Событие Entity Framework.
    /// </summary>
    public class AuditEfEvent
    {
        /// <summary>
        /// Список действий с сущностями.
        /// <para/>
        /// Тип: <see cref="List{AuditEntry}"/>
        /// </summary>
        public List<AuditEntry> Entries { get; set; } = new();

        /// <summary>
        /// Статус выполнения.
        /// <para/>
        /// Тип: <see langword="bool"/>
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Имя базы данных, в которой произошло событие.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// </summary>
        public string Database { get; set; } = null!;

        /// <summary>
        /// Идентификатор контекста EF.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// </summary>
        public string ContextId { get; set; } = null!;
    }

    /// <summary>
    /// DTO аудита для EF-событий.
    /// </summary>
    public class AuditLogDto
    {
        /// <summary>
        /// Тип события.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// </summary>
        public string EventType { get; set; } = null!;

        /// <summary>
        /// Время начала события.
        /// <para/>
        /// Тип: <see langword="DateTime"/>
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Время окончания события.
        /// <para/>
        /// Тип: <see langword="DateTime"/>
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Продолжительность события в миллисекундах.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Событие Entity Framework.
        /// <para/>
        /// Тип: <see cref="AuditEfEvent"/>
        /// </summary>
        public AuditEfEvent EntityFrameworkEvent { get; set; } = new();
    }
}
