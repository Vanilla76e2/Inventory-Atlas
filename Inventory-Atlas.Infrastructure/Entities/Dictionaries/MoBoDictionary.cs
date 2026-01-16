using Inventory_Atlas.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using Inventory_Atlas.Infrastructure.Entities.Base;
using Inventory_Atlas.Infrastructure.Entities.Technics.Components;

namespace Inventory_Atlas.Infrastructure.Entities.Dictionaries
{
    /// <summary>
    /// Материнская плата (Motherboard, MoBo).
    /// <para/>
    /// Содержит информацию о производителе, модели, сокете, чипсете, форм-факторе,
    /// слотах для RAM, PCIe и M.2, а также связанных компонентах.
    /// </summary>
    [Table("MoBos", Schema = "Dictionaries")]
    public class MoBoDictionary : AuditableEntity
    {
        /// <summary>
        /// Производитель материнской платы.
        /// <para/>
        /// Тип: <see cref="string"/>.
        /// <para/>
        /// Обязательное поле, не может быть null.
        /// </summary>
        [Column("vendor")]
        public string Vendor { get; set; } = null!;

        /// <summary>
        /// Модель материнской платы.
        /// <para/>
        /// Тип: <see cref="string"/>.
        /// <para/>
        /// Обязательное поле, не может быть null.
        /// </summary>
        [Column("model")]
        public string Model { get; set; } = null!;

        /// <summary>
        /// Тип сокета процессора.
        /// <para/>
        /// Тип: <see cref="string"/>?.
        /// <para/>
        /// Может быть null, если информация не указана.
        /// </summary>
        [Column("socket")]
        public string? Socket { get; set; } = null!;

        /// <summary>
        /// Чипсет материнской платы.
        /// <para/>
        /// Тип: <see cref="string"/>?.
        /// <para/>
        /// Может быть null, если информация не указана.
        /// </summary>
        [Column("chipset")]
        public string? Chipset { get; set; } = null!;

        /// <summary>
        /// Форм-фактор материнской платы.
        /// <para/>
        /// Тип: <see cref="MoBoFormFactor"/>.
        /// </summary>
        [Column("form_factor")]
        public MoBoFormFactor FormFactor { get; set; }

        /// <summary>
        /// Количество слотов для оперативной памяти.
        /// <para/>
        /// Тип: <see cref="short"/>?.
        /// <para/>
        /// Может быть null, если информация неизвестна.
        /// </summary>
        [Column("ram_slots")]
        public short? RamSlots { get; set; }

        /// <summary>
        /// Количество слотов PCIe.
        /// <para/>
        /// Тип: <see cref="short"/>?.
        /// <para/>
        /// Может быть null, если информация неизвестна.
        /// </summary>
        [Column("pcie_slots")]
        public short? PcieSlots { get; set; }

        /// <summary>
        /// Количество слотов M.2.
        /// <para/>
        /// Тип: <see cref="short"/>?.
        /// <para/>
        /// Может быть null, если информация неизвестна.
        /// </summary>
        [Column("m2_slots")]
        public short? M2Slots { get; set; }

        /// <summary>
        /// Коллекция компонентов материнской платы, использующих эту модель.
        /// <para/>
        /// Тип: <see cref="ICollection{MoBoComponent}"/>.
        /// <para/>
        /// Навигационное свойство для получения всех связанных компонентов.
        /// </summary>
        [InverseProperty(nameof(MoBoComponent.MoBoReference))]
        public virtual ICollection<MoBoComponent> MoBos { get; set; } = new List<MoBoComponent>();
    }
}
