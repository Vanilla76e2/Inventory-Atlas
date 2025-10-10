using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Technics.Components
{
    /// <summary>
    /// Компонент компьютера, представляющий материнскую плату (MoBo).
    /// <para/>
    /// Наследуется от <see cref="ComputerComponent"/> и является конкретной моделью материнской платы, используемой в устройстве.
    /// </summary>
    [Table("ComputerComponents_MoBo", Schema = "Technics")]
    public class MoBoComponent : ComputerComponent
    {
        /// <summary>
        /// Идентификатор материнской платы, которой является данный компонент.
        /// <para/>
        /// Тип: <see cref="int"/>.
        /// </summary>
        [Column("mobo_id")]
        public int MoBoId { get; set; }

        /// <summary>
        /// Навигационное свойство на материнскую плату.
        /// <para/>
        /// Тип: <see cref="References.MoBoDictionary"/>.
        /// <para/>
        /// Позволяет получить информацию о модели материнской платы, которой является данный компонент.
        /// </summary>
        [ForeignKey(nameof(MoBoId))]
        public virtual References.MoBoDictionary MoBoReference { get; set; } = null!;
    }
}
