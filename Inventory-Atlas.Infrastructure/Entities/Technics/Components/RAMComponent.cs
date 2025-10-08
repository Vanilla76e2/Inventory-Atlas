using Inventory_Atlas.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Technics.Components
{
    /// <summary>
    /// Компонент компьютера, представляющий модуль оперативной памяти (RAM).
    /// <para/>
    /// Наследуется от <see cref="ComputerComponent"/> и содержит информацию о типе DDR, объёме модуля и частоте.
    /// </summary>
    [Table("ComputerComponents_RAM", Schema = "Technics")]
    public class RAMComponent : ComputerComponent
    {
        /// <summary>
        /// Тип DDR памяти.
        /// <para/>
        /// Тип: <see cref="DDRType"/>.
        /// </summary>
        [Column("ddr_type")]
        public DDRType DdrType { get; set; }

        /// <summary>
        /// Объём модуля памяти в гигабайтах.
        /// <para/>
        /// Тип: <see cref="short"/>.
        /// </summary>
        [Column("size")]
        public short Size { get; set; } // in GB

        /// <summary>
        /// Частота модуля памяти в мегагерцах (MHz).
        /// <para/>
        /// Тип: <see cref="int"/>?.
        /// <para/>
        /// Может быть null, если частота не указана.
        /// </summary>
        [Column("frequency")]
        public int? Frequency { get; set; }
    }
}
