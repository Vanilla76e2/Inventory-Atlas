using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Documents
{
    /// <summary>
    /// DTO для документа передачи оборудования от одного сотрудника другому.
    /// <para/>
    /// Тип: <see cref="TransferDocumentDto"/>
    /// <para/>
    /// Наследуется от <see cref="DocumentDto"/> и содержит информацию об исходном и целевом сотруднике, а также элементы передачи.
    /// </summary>
    public class TransferDocumentDto : DocumentDto
    {
        /// <summary>
        /// Идентификатор сотрудника, который передаёт оборудование.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int FromEmployeeId { get; set; }

        /// <summary>
        /// Имя сотрудника, который передаёт оборудование.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string FromEmployeeName { get; set; } = null!;

        /// <summary>
        /// Идентификатор сотрудника, который принимает оборудование.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int ToEmployeeId { get; set; }

        /// <summary>
        /// Имя сотрудника, который принимает оборудование.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string ToEmployeeName { get; set; } = null!;

        /// <summary>
        /// Список элементов документа передачи.
        /// <para/>
        /// Тип: <see cref="List{TransferDocumentItemDto}"/>
        /// <para/>
        /// Всегда инициализирован пустым списком, не может быть <c>null</c>.
        /// </summary>
        public List<TransferDocumentItemDto> Items { get; set; } = new();
    }

    /// <summary>
    /// Сокращённый DTO для документа передачи оборудования от одного сотрудника другому.
    /// </summary>
    public class TransferDocumentListDto : DocumentDto
    {
        /// <summary>
        /// Имя сотрудника, который передаёт оборудование.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string FromEmployeeName { get; set; } = null!;

        /// <summary>
        /// Имя сотрудника, который принимает оборудование.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string ToEmployeeName { get; set; } = null!;

        /// <summary>
        /// Количество элементов в документе передачи.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int ItemsCount { get; set; }
    }

    /// <summary>
    /// DTO для отдельного элемента документа передачи оборудования.
    /// <para/>
    /// Тип: <see cref="TransferDocumentItemDto"/>
    /// </summary>
    public class TransferDocumentItemDto : BaseDto
    {
        /// <summary>
        /// Идентификатор документа передачи, к которому принадлежит элемент.
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
        /// Инвентарный номер элемента документа.
        /// <para/>
        /// Тип: <see langword="long"/>
        /// </summary>
        public string? ItemInventoryNumber { get; set; }
    }
}
