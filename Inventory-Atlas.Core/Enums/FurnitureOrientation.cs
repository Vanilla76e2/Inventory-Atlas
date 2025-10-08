using System.ComponentModel.DataAnnotations;

namespace Inventory_Atlas.Core.Enums
{
    /// <summary>
    /// Ориентация мебели.
    /// <para/>
    /// Используется для указания формы или расположения мебели в пространстве.
    /// </summary>
    public enum FurnitureOrientation
    {
        /// <summary>
        /// Нет ориентации, стандартная прямоугольная форма.
        /// </summary>
        [Display(Name = "Нет")]
        None = 0,

        /// <summary>
        /// Прямая форма мебели (обычная прямолинейная конструкция).
        /// </summary>
        [Display(Name = "Прямой")]
        Straight = 1,

        /// <summary>
        /// Угловая мебель с левым расположением угла.
        /// </summary>
        [Display(Name = "Угловой левый")]
        CornerLeft = 2,

        /// <summary>
        /// Угловая мебель с правым расположением угла.
        /// </summary>
        [Display(Name = "Угловой правый")]
        CornerRight = 3
    }
}
