using Inventory_Atlas.Core.DTOs.Common;
using Inventory_Atlas.Core.Enums;

namespace Inventory_Atlas.Core.DTOs.Inventory
{
    /// <summary>
    /// DTO для элемента инвентаря с поддержкой мягкого удаления.
    /// <para/>
    /// Тип: <see cref="InventoryItemDto"/>
    /// <para/>
    /// Наследуется от <see cref="SoftDeletableDto"/> и содержит информацию о номере, ответственном, местоположении, статусе, названии, комментарии и фотографиях.
    /// </summary>
    public class InventoryItemDto : BaseDto
    {
        /// <summary>
        /// Название элемента.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Инвентарный номер элемента.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c> если номер не назначен.
        /// </summary>
        public string? InventoryNumber { get; set; }

        /// <summary>
        /// Реестровый номер.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? RegistryNumber { get; set; }

        /// <summary>
        /// Идентификатор ответственного сотрудника.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// <para/>
        /// Может быть <c>null</c> если ответственный не назначен.
        /// </summary>
        public int? ResponsibleId { get; set; }

        /// <summary>
        /// Имя ответственного сотрудника.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? ResponsibleName { get; set; }

        /// <summary>
        /// Местоположение элемента.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? Location { get; set; }

        /// <summary>
        /// Статус элемента инвентаря.
        /// <para/>
        /// Тип: <see cref="InventoryStatus"/>
        /// </summary>
        public InventoryStatus Status { get; set; }

        /// <summary>
        /// Комментарий к элементу инвентаря.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? Comment { get; set; }

        /// <summary>
        /// Идентификатор категории инвентарного объекта.
        /// <para/>
        /// Тип: <see langword="int"/>?.
        /// </summary>
        public int? CategoryId { get; set; }

        /// <summary>
        /// Имя категории инвентарного объекта.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// </summary>
        public string? CategoryName { get; set; }

        /// <summary>
        /// Список фотографий элемента.
        /// <para/>
        /// Тип: <see cref="List{InventoryPhotoDto}"/>
        /// <para/>
        /// Может быть <c>null</c> если фотографии не добавлены.
        /// </summary>
        public List<InventoryPhotoDto>? Photos { get; set; }
    }
}
