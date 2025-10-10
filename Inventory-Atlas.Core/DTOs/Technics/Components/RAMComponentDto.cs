namespace Inventory_Atlas.Core.DTOs.Technics.Components
{
    /// <summary>
    /// DTO для оперативной памяти как компонента компьютера.
    /// <para/>
    /// Тип: <see cref="RAMComponentDto"/>
    /// <para/>
    /// Наследуется от <see cref="ComputerComponentDto"/> и содержит информацию о типе DDR, объеме и частоте памяти.
    /// </summary>
    public class RAMComponentDto : ComputerComponentDto
    {
        /// <summary>
        /// Тип DDR памяти.
        /// <para/>
        /// Тип: <see cref="Enums.DDRType"/>
        /// </summary>
        public Enums.DDRType DdrType { get; set; }

        /// <summary>
        /// Размер модуля памяти в ГБ.
        /// <para/>
        /// Тип: <see langword="short"/>
        /// </summary>
        public short Size { get; set; }

        /// <summary>
        /// Частота памяти в МГц.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public int? Frequency { get; set; }
    }
}
