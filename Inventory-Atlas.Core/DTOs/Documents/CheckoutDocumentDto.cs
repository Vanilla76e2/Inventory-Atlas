using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Documents
{
    /// <summary>
    /// DTO для документа выдачи оборудования сотруднику.
    /// <para/>
    /// Тип: <see cref="CheckoutDocumentDto"/>
    /// <para/>
    /// Наследуется от <see cref="DocumentDto"/> и содержит информацию о сотруднике и элементах документа.
    /// </summary>
    public class CheckoutDocumentDto : DocumentDto
    {
        /// <summary>
        /// Идентификатор сотрудника, которому выдано оборудование.
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
        /// Список элементов документа выдачи.
        /// <para/>
        /// Тип: <see cref="List{CheckoutDocumentItemDto}"/>
        /// <para/>
        /// Всегда инициализирован пустым списком, не может быть <c>null</c>.
        /// </summary>
        public List<CheckoutDocumentItemDto> Items { get; set; } = new();
    }

    /// <summary>
    /// DTO для отдельного элемента документа выдачи оборудования.
    /// <para/>
    /// Тип: <see cref="CheckoutDocumentItemDto"/>
    /// </summary>
    public class CheckoutDocumentItemDto : BaseDto
    {
        /// <summary>
        /// Идентификатор документа, к которому принадлежит элемент.
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
