namespace Inventory_Atlas.Core.DTOs.Technics.Components
{
    /// <summary>
    /// DTO для сетевого компонента компьютера.
    /// <para/>
    /// Тип: <see cref="NetworkComponentDto"/>
    /// <para/>
    /// Наследуется от <see cref="ComputerComponentDto"/> и содержит информацию о модели, MAC-адресе, оптическом интерфейсе и скорости.
    /// </summary>
    public class NetworkComponentDto : ComputerComponentDto
    {
        /// <summary>
        /// Модель сетевого компонента.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string Model { get; set; } = null!;

        /// <summary>
        /// MAC-адрес устройства.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? MACAddress { get; set; }

        /// <summary>
        /// Признак оптического интерфейса.
        /// <para/>
        /// Тип: <see langword="bool"/>
        /// </summary>
        public bool Optical { get; set; }

        /// <summary>
        /// Скорость сетевого интерфейса в Мбит/с.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public int? Speed { get; set; }
    }
}
