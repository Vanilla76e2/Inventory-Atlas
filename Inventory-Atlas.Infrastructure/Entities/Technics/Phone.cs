using Inventory_Atlas.Infrastructure.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Technics
{
    /// <summary>
    /// Сущность телефона.
    /// <para/>
    /// Наследуется от <see cref="DeviceEntity"/> и содержит модель, производителя и номер телефона.
    /// </summary>
    [Table("Phones", Schema = "Technics")]
    public class Phone : DeviceEntity
    {
        /// <summary>
        /// Номер телефона.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>. Максимальная длина — 18 символов.
        /// </summary>
        [Column("phone_number")]
        [StringLength(18)]
        public string? PhoneNumber { get; set; }
    }
}
