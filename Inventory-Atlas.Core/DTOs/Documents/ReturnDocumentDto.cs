using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Documents
{
    /// <summary>
    /// DTO для документа возврата оборудования от сотрудника.
    /// <para/>
    /// Тип: <see cref="ReturnDocumentDto"/>
    /// <para/>
    /// Наследуется от <see cref="DocumentDto"/> и содержит информацию о сотруднике и элементах возврата.
    /// </summary>
    public class ReturnDocumentDto : DocumentDto
    {
        /// <summary>
        /// Идентификатор сотрудника, который возвращает оборудование.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Имя сотрудника.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string EmployeeName { get; set; } = null!;

        /// <summary>
        /// Список элементов документа возврата.
        /// <para/>
        /// Тип: <see cref="List{ReturnDocumentItemDto}"/>
        /// <para/>
        /// Всегда инициализирован пустым списком, не может быть <c>null</c>.
        /// </summary>
        public List<ReturnDocumentItemDto> Items { get; set; } = new();
    }

    public class ReturnDocumentListDto : DocumentDto
    {
        /// <summary>
        /// Имя сотрудника.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string EmployeeName { get; set; } = null!;

        /// <summary>
        /// Количество элементов в документе.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int ItemsCount { get; set; }
    }

    /// <summary>
    /// DTO для отдельного элемента документа возврата оборудования.
    /// <para/>
    /// Тип: <see cref="ReturnDocumentItemDto"/>
    /// </summary>
    public class ReturnDocumentItemDto : BaseDto
    {
        /// <summary>
        /// Идентификатор документа возврата, к которому принадлежит элемент.
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

        /// <summary>
        /// Инвентарный номер элемента.
        /// <para/>
        /// Тип: <see langword="long"/>
        /// </summary>
        public string? ItemInventoryNumber { get; set; }

    }
}
