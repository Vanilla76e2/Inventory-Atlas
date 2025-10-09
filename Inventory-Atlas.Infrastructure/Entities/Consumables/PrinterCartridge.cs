using Inventory_Atlas.Infrastructure.Entities.Base;
using Inventory_Atlas.Infrastructure.Entities.Technics;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Сonsumables
{
    /// <summary>
    /// Картридж для принтера.
    /// <para/>
    /// Содержит название, модель, количество и список принтеров, использующих этот картридж.
    /// </summary>
    [Table("PrinterCartridges", Schema = "Consumables")]
    public class PrinterCartridge : AuditableEntity
    {
        /// <summary>
        /// Название картриджа.
        /// <para/>
        /// Тип: <see langword="string"/>.
        /// <para/>
        /// Не может быть <see langword="null"/>.
        /// </summary>
        [Column("name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Модель картриджа.
        /// <para/>
        /// Тип: <see langword="string"/>.
        /// <para/>
        /// Не может быть <see langword="null"/>.
        /// </summary>
        [Column("model")]
        public string Model { get; set; } = null!;

        /// <summary>
        /// Количество картриджей на складе.
        /// <para/>
        /// Тип: <see langword="int"/>.
        /// <para/>
        /// По умолчанию 0.
        /// </summary>
        [Column("quantity")]
        public int Quantity { get; set; } = 0;

        /// <summary>
        /// Коллекция принтеров, использующих данный картридж.
        /// <para/>
        /// Тип: <see cref="ICollection{Printer}"/>.
        /// <para/>
        /// Не может быть <see langword="null"/>.
        /// </summary>
        [InverseProperty(nameof(Printer.Cartridge))]
        public virtual ICollection<Printer> Printers { get; set; } = new List<Printer>();
    }
}
