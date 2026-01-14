using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Application.Entities.Technics.Components
{
    /// <summary>
    /// Прочий компонент компьютера.
    /// <para/>
    /// Используется для хранения данных о компонентах, не попадающих под стандартные категории (например, адаптеры, контроллеры и т.д.).
    /// </summary>
    [Table("OtherComponents", Schema = "Technics")]
    public class OtherComponent : ComputerComponent
    {
        /// <summary>
        /// Наименование компонента.
        /// <para/>
        /// Тип: <see langword="string"/>.
        /// <para/>
        /// Обязательное поле, не может быть <see langword="null"/>.
        /// </summary>
        [Column("name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Описание компонента.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("description")]
        public string? Description { get; set; }
    }
}
