namespace Inventory_Atlas.Core.DTOs.Technics.Components
{
    /// <summary>
    /// DTO для блока питания компьютера.
    /// <para/>
    /// Тип: <see cref="PsuComponentDto"/>
    /// <para/>
    /// Наследуется от <see cref="ComputerComponentDto"/> и содержит информацию о мощности блока питания.
    /// </summary>
    public class PsuComponentDto : ComputerComponentDto
    {
        /// <summary>
        /// Мощность блока питания в ваттах.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int Wattage { get; set; }
    }
}
