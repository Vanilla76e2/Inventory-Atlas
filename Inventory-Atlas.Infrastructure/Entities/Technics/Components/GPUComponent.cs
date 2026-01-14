using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Application.Entities.Technics.Components
{
    /// <summary>
    /// Компонент компьютера, представляющий видеокарту (GPU).
    /// <para/>
    /// Наследуется от <see cref="ComputerComponent"/> и является конкретной моделью GPU, используемой в устройстве.
    /// </summary>
    [Table("ComputerComponents_GPU", Schema = "Technics")]
    public class GpuComponent : ComputerComponent
    {
        /// <summary>
        /// Идентификатор видеокарты, которой является данный компонент.
        /// <para/>
        /// Тип: <see cref="int"/>.
        /// </summary>
        [Column("gpu_id")]
        public int GpuId { get; set; }


        /// <summary>
        /// Навигационное свойство на видеокарту.
        /// <para/>
        /// Тип: <see cref="References.GpuDictionary"/>.
        /// <para/>
        /// Позволяет получить информацию о модели GPU, которой является данный компонент.
        /// </summary>
        [ForeignKey(nameof(GpuId))]
        public virtual References.GpuDictionary GPUReference { get; set; } = null!;
    }
}
