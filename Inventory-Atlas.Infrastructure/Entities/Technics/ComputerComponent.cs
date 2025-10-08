using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Infrastructure.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Technics
{
    /// <summary>
    /// Сущность, описывающая компонент компьютера.
    /// <para/>
    /// Содержит информацию о компьютере, к которому относится компонент,
    /// типе компонента, его количестве и серийном номере.
    /// </summary>
    [Table("ComputerComponents", Schema = "Technics")]
    public class ComputerComponent : BaseEntity
    {
        /// <summary>
        /// Идентификатор компьютера, к которому относится компонент.
        /// <para/>
        /// Тип: <see langword="int"/>.
        /// <para/>
        /// Не может быть <see langword="null"/>.
        /// </summary>
        [Column("computer_id")]
        public int ComputerId { get; set; }

        /// <summary>
        /// Навигационное свойство для компьютера, которому принадлежит компонент.
        /// <para/>
        /// Тип: <see cref="Technics.Computer"/>.
        /// <para/>
        /// Не может быть <see langword="null"/>.
        /// </summary>
        [ForeignKey(nameof(ComputerId))]
        public virtual Computer Computer { get; set; } = null!;

        /// <summary>
        /// Тип компонента.
        /// <para/>
        /// Тип: <see cref="Core.Enums.ComponentType"/>.
        /// <para/>
        /// По умолчанию <see cref="ComponentType.Other"/>.
        /// </summary>
        [Column("component_type")]
        public ComponentType ComponentType { get; set; } = ComponentType.Other;

        /// <summary>
        /// Количество экземпляров данного компонента.
        /// <para/>
        /// Тип: <see langword="short"/>.
        /// <para/>
        /// Значение по умолчанию: 1.
        /// </summary>
        [Column("quantity")]
        public short Quantity { get; set; } = 1;

        /// <summary>
        /// Серийный номер комплектующей.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("serial_number")]
        public string? SerialNumber { get; set; }
    }
}
