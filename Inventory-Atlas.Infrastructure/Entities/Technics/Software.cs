using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Application.Entities.Technics
{
    /// <summary>
    /// Сущность программного обеспечения.
    /// <para/>
    /// Наследуется от <see cref="Equipment"/> и содержит информацию о лицензии и поставщике.
    /// </summary>
    [Table("Software", Schema = "Technics")]
    public class Software : Equipment
    {
        /// <summary>
        /// Лицензионный ключ программного обеспечения.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("licence_key")]
        public string? LicenceKey { get; set; }

        /// <summary>
        /// Поставщик программного обеспечения.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("vendor")]
        public string? Vendor {  get; set; }
    }
}
