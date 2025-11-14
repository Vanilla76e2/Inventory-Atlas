using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Technics.Components
{
    /// <summary>
    /// Компонент компьютера, представляющий блок питания (PSU).
    /// <para/>
    /// Наследуется от <see cref="ComputerComponent"/> и содержит информацию о мощности блока питания, используемого в устройстве.
    /// </summary>
    [Table("ComputerComponents_PSU", Schema = "Technics")]
    public class PsuComponent : ComputerComponent
    {
        /// <summary>
        /// Мощность блока питания в ваттах.
        /// <para/>
        /// Тип: <see cref="int"/>.
        /// <para/>
        /// Обязательное поле, указывает на максимальную мощность.
        /// </summary>
        [Column("Wattage")]
        public int Wattage { get; set; }
    }
}
