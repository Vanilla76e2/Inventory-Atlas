using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Application.Entities.Technics.Components
{
    /// <summary>
    /// Компонент компьютера, представляющий накопитель (Storage).
    /// <para/>
    /// Наследуется от <see cref="ComputerComponent"/> и содержит информацию о типе накопителя и его объёме.
    /// </summary>
    [Table("ComputerComponents_Storage", Schema = "Technics")]
    public class StorageComponent : ComputerComponent
    {
        /// <summary>
        /// Тип накопителя (SSD, HDD, NVMe и др.).
        /// <para/>
        /// Тип: <see cref="DriveType"/>.
        /// </summary>
        [Column("storage_type")]
        public Core.Enums.DriveType StorageType { get; set; } // e.g., SSD, HDD, NVMe

        /// <summary>
        /// Объём накопителя в гигабайтах (GB).
        /// <para/>
        /// Тип: <see cref="int"/>.
        /// </summary>
        [Column("capacity")]
        public int Capacity { get; set; } // in GB
    }
}
