using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Documents
{
    /// <summary>
    /// DTO для документа списания оборудования.
    /// <para/>
    /// Тип: <see cref="WriteOffDocumentDto"/>
    /// <para/>
    /// Наследуется от <see cref="DocumentDto"/> и содержит причину списания и элементы документа.
    /// </summary>
    public class WriteOffDocumentDto : DocumentDto
    {
        /// <summary>
        /// Причина списания оборудования.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c> если причина не указана.
        /// </summary>
        public string? Reason { get; set; }

        /// <summary>
        /// Список элементов документа списания.
        /// <para/>
        /// Тип: <see cref="List{WriteOffDocumentItemDto}"/>
        /// <para/>
        /// Всегда инициализирован пустым списком, не может быть <c>null</c>.
        /// </summary>
        public List<WriteOffDocumentItemDto> Items { get; set; } = new();
    }

    /// <summary>
    /// DTO для отдельного элемента документа списания оборудования.
    /// <para/>
    /// Тип: <see cref="WriteOffDocumentItemDto"/>
    /// </summary>
    public class WriteOffDocumentItemDto : BaseDto
    {
        /// <summary>
        /// Идентификатор документа списания, к которому принадлежит элемент.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int DocumentId { get; set; }

        /// <summary>
        /// Идентификатор элемента (оборудования).
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// Название элемента (оборудования).
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string ItemName { get; set; } = null!;
    }
}
