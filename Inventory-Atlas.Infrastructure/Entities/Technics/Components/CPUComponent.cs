using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Technics.Components
{
    /// <summary>
    /// Компонент компьютера, представляющий процессор (CPU).
    /// <para/>
    /// Наследуется от <see cref="ComputerComponent"/> и cодержит информацию о принадлежности к конкретной модели CPU.
    /// </summary>
    [Table("ComputerComponents_CPU", Schema = "Technics")]
    public class CPUComponent : ComputerComponent
    {
        /// <summary>
        /// Идентификатор процессора, являющегося компонентом.
        /// <para/>
        /// Тип: <see cref="int"/>.
        /// </summary>
        [Column("cpu_id")]
        public int CPUId { get; set; }

        /// <summary>
        /// Навигационное свойство на процессор.
        /// <para/>
        /// Тип: <see cref="References.CPU"/>.
        /// <para/>
        /// Позволяет получить информацию о модели CPU, которой является данный компонент.
        /// </summary>
        [ForeignKey(nameof(CPUId))]
        public virtual References.CPU CPUReference { get; set; } = null!;
    }
}
