namespace Inventory_Atlas.Core.DTOs.Technics.Components
{
    /// <summary>
    /// DTO для звукового компонента компьютера.
    /// <para/>
    /// Тип: <see cref="SoundComponentDto"/>
    /// <para/>
    /// Наследуется от <see cref="ComputerComponentDto"/> и содержит информацию о модели, количестве каналов и внешнем исполнении.
    /// </summary>
    public class SoundComponentDto : ComputerComponentDto
    {
        /// <summary>
        /// Модель звукового компонента.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string Model { get; set; } = null!;

        /// <summary>
        /// Количество звуковых каналов.
        /// <para/>
        /// Тип: <see langword="short"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public short? Channels { get; set; }

        /// <summary>
        /// Признак внешнего устройства.
        /// <para/>
        /// Тип: <see langword="bool"/>
        /// </summary>
        public bool IsExternal { get; set; }
    }
}
