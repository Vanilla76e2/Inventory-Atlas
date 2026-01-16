using Inventory_Atlas.Infrastructure.Entities.Technics;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Technics.Components
{
    /// <summary>
    /// Компонент компьютера, представляющий звуковую карту.
    /// <para/>
    /// Наследуется от <see cref="ComputerComponent"/> и содержит информацию о модели карты и количестве каналов.
    /// </summary>
    [Table("ComputerComponent_SoundCard", Schema = "Technics")]
    public class SoundComponent : ComputerComponent
    {
        /// <summary>
        /// Модель звуковой карты.
        /// <para/>
        /// Тип: <see cref="string"/>.
        /// <para/>
        /// Обязательное поле, не может быть null.
        /// </summary>
        [Column("model")]
        public string Model { get; set; } = null!;

        /// <summary>
        /// Количество аудиоканалов.
        /// <para/>
        /// Тип: <see cref="short"/>?.
        /// <para/>
        /// Может быть null, если количество каналов не указано.
        /// </summary>
        [Column("channels")]
        public short? Channels { get; set; }

        /// <summary>
        /// Флаг, указывающий, является ли звуковая карта внешней.
        /// <para/>
        /// Тип: <see langword="bool"/>.
        /// <para/>
        /// По умолчанию <see langword="false"/>.
        /// </summary>
        [Column("is_external")]
        public bool IsExternal { get; set; }
    }
}
