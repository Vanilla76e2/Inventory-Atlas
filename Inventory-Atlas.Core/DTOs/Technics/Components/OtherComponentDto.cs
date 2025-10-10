namespace Inventory_Atlas.Core.DTOs.Technics.Components
{
    /// <summary>
    /// DTO для прочих компонентов компьютера, не относящихся к стандартным категориям.
    /// <para/>
    /// Тип: <see cref="OtherComponentDto"/>
    /// <para/>
    /// Наследуется от <see cref="ComputerComponentDto"/> и содержит название и описание компонента.
    /// </summary>
    public class OtherComponentDto : ComputerComponentDto
    {
        /// <summary>
        /// Название компонента.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Описание компонента.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? Description { get; set; }
    }
}
