namespace Inventory_Atlas.Core.DTOs.Technics.Components
{
    /// <summary>
    /// DTO для процессорного компонента компьютера.
    /// <para/>
    /// Тип: <see cref="CPUComponentDto"/>
    /// <para/>
    /// Наследуется от <see cref="ComputerComponentDto"/> и содержит данные о процессоре: идентификатор, название, производителя, количество ядер и потоков, тактовую частоту и сокет.
    /// </summary>
    public class CPUComponentDto : ComputerComponentDto
    {
        /// <summary>
        /// Идентификатор процессора.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int CPUId { get; set; }

        /// <summary>
        /// Название процессора.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string CPUName { get; set; } = null!;

        /// <summary>
        /// Производитель процессора.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? CPUManufacturer { get; set; }

        /// <summary>
        /// Количество физических ядер процессора.
        /// <para/>
        /// Тип: <see langword="short"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public short? CoreCount { get; set; }

        /// <summary>
        /// Количество потоков процессора.
        /// <para/>
        /// Тип: <see langword="short"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public short? ThreadCount { get; set; }

        /// <summary>
        /// Тактовая частота процессора в ГГц.
        /// <para/>
        /// Тип: <see langword="double"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public double? Clock { get; set; }

        /// <summary>
        /// Тип сокета процессора.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? Socket { get; set; }
    }
}
