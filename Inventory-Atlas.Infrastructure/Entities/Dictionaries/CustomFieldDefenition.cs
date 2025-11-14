using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Infrastructure.Entities.Base;
using Inventory_Atlas.Infrastructure.Entities.Services;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Dictionaries
{
    /// <summary>
    /// Свойства пользовательского поля.
    /// </summary>
    [Table("CustomFieldDefenitionDto", Schema = "Dictionaries")]
    public class CustomFieldDefenition : BaseEntity
    {
        /// <summary>
        /// Идентификатор категории инвентарного объекта.
        /// <para/>
        /// Тип: <see langword="int"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("category_id")]
        public int? CategoryId { get; set; }

        /// <summary>
        /// Объект представляющий категорию инвентарного объекта.
        /// <para/>
        /// Тип: <see cref="InventoryCategory"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [ForeignKey(nameof(CategoryId))]
        public virtual InventoryCategory? Category { get; set; }

        /// <summary>
        /// Наименование пользовательского поля.
        /// <para/>
        /// Тип: <see langword="string"/>.
        /// </summary>
        [Column("field_name")]
        public string FieldName { get; set; } = null!;

        /// <summary>
        /// Тип данных пользовательского поля.
        /// <para/>
        /// Тип: <see cref="DataTypeEnum"/>.
        /// </summary>
        [Column("data_type")]
        public DataTypeEnum DataType { get; set; }

        /// <summary>
        /// Флаг определяющий обязательность пользовательского поля.
        /// <para/>
        /// Тип: <see langword="bool"/>.
        /// </summary>
        [Column("is_required")]
        public bool IsRequired { get; set; }

        /// <summary>
        /// Порядок расположения пользовательских полей.
        /// <para/>
        /// Тип: <see langword="int"/>.
        /// </summary>
        [Column("order")]
        public int Order { get; set; }

        /// <summary>
        /// Коллекция значений полей.
        /// <para/>
        /// Тип: Коллекция <see cref="CustomFieldValue"/>.
        /// </summary>
        [InverseProperty(nameof(CustomFieldValue.FieldDefenition))]
        public ICollection<CustomFieldValue> FieldValues { get; set; } = new List<CustomFieldValue>();
    }
}
