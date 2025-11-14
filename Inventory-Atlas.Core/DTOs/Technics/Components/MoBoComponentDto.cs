namespace Inventory_Atlas.Core.DTOs.Technics.Components
{
    /// <summary>
    /// DTO для материнской платы как компонента компьютера.
    /// <para/>
    /// Тип: <see cref="MoBoComponentDto"/>
    /// <para/>
    /// Наследуется от <see cref="ComputerComponentDto"/> и содержит информацию о материнской плате: идентификатор, производителя, модель, сокет, чипсет, форм-фактор, количество слотов RAM, максимальный объем RAM, PCIe и M.2 слоты.
    /// </summary>
    public class MoBoComponentDto : ComputerComponentDto
    {
        /// <summary>
        /// Идентификатор материнской платы.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int MoBoId { get; set; }

        /// <summary>
        /// Производитель материнской платы.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string Vendor { get; set; } = null!;

        /// <summary>
        /// Модель материнской платы.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string Model { get; set; } = null!;

        /// <summary>
        /// Тип сокета процессора.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? Socket { get; set; }

        /// <summary>
        /// Чипсет материнской платы.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? Chipset { get; set; }

        /// <summary>
        /// Форм-фактор материнской платы.
        /// <para/>
        /// Тип: <see cref="Enums.MoBoFormFactor"/>
        /// </summary>
        public Enums.MoBoFormFactor FormFactor { get; set; }

        /// <summary>
        /// Количество слотов RAM.
        /// <para/>
        /// Тип: <see langword="short"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public short? RamSlots { get; set; }

        /// <summary>
        /// Количество PCIe слотов.
        /// <para/>
        /// Тип: <see langword="short"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public short? PcieSlots { get; set; }

        /// <summary>
        /// Количество M.2 слотов.
        /// <para/>
        /// Тип: <see langword="short"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public short? M2Slots { get; set; }
    }
}
