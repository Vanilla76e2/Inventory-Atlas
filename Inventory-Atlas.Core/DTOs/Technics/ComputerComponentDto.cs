namespace Inventory_Atlas.Core.DTOs.Technics
{
    /// <summary>
    /// DTO для компонента компьютера.
    /// <para/>
    /// Тип: <see cref="ComputerComponentDto"/>
    /// <para/>
    /// Содержит общие свойства для всех компонентов, включая идентификаторы, тип компонента, количество и серийный номер.
    /// </summary>
    public class ComputerComponentDto
    {
        /// <summary>
        /// Идентификатор компонента.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор компьютера, к которому принадлежит компонент.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int ComputerId { get; set; }

        /// <summary>
        /// Тип компонента.
        /// <para/>
        /// Тип: <see cref="Enums.ComponentType"/>
        /// </summary>
        public Enums.ComponentType ComponentType { get; set; }

        /// <summary>
        /// Количество данного компонента.
        /// <para/>
        /// Тип: <see langword="short"/>
        /// </summary>
        public short Quantity { get; set; }

        /// <summary>
        /// Серийный номер компонента.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? SerialNumber { get; set; }
    }
}
