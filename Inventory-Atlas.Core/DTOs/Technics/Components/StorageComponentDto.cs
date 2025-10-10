namespace Inventory_Atlas.Core.DTOs.Technics.Components
{
    /// <summary>
    /// DTO для накопителя как компонента компьютера.
    /// <para/>
    /// Тип: <see cref="StorageComponentDto"/>
    /// <para/>
    /// Наследуется от <see cref="ComputerComponentDto"/> и содержит информацию о типе накопителя и его емкости.
    /// </summary>
    public class StorageComponentDto : ComputerComponentDto
    {
        /// <summary>
        /// Тип накопителя (HDD, SSD и т.п.).
        /// <para/>
        /// Тип: <see cref="Enums.DriveType"/>
        /// </summary>
        public Enums.DriveType StorageType { get; set; }

        /// <summary>
        /// Емкость накопителя в ГБ.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int Capacity { get; set; }
    }
}
