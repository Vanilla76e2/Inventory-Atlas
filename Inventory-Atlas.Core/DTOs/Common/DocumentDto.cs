using Inventory_Atlas.Core.Enums;

namespace Inventory_Atlas.Core.DTOs.Common
{
    /// <summary>
    /// DTO для документов с информацией для аудита.
    /// <para/>
    /// Тип: <see cref="DocumentDto"/>
    /// <para/>
    /// Наследуется от <see cref="BaseDto"/>, содержит дату, название, комментарий и тип документа.
    /// </summary>
    public class DocumentDto : AuditableDto
    {
        /// <summary>
        /// Номер документа.
        /// <para/>
        /// Тип: <see langword="int"/>.
        /// <para/>
        /// Не может быть <see langword="null"/>.
        /// </summary>
        public int DocumentNumber { get; set; }

        /// <summary>
        /// Дата документа.
        /// <para/>
        /// Тип: <see langword="DateTime"/>
        /// </summary>
        public DateTime DocumentDate { get; set; }

        /// <summary>
        /// Название документа.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c> если название не указано.
        /// </summary>
        public string? DocumentName { get; set; }

        /// <summary>
        /// Наименование материально ответственного лица.
        /// <para/>
        /// Тип: <see langword="string"/>.
        /// </summary>
        public string MatriallyResponibleDisplayName { get; set; } = null!;

        /// <summary>
        /// Комментарий к документу.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c> если комментарий отсутствует.
        /// </summary>
        public string? Comment { get; set; }

        /// <summary>
        /// Тип документа.
        /// <para/>
        /// Тип: <see cref="DocumentStatus"/>
        /// </summary>
        public DocumentStatus DocumentStatus { get; set; }
    }
}
