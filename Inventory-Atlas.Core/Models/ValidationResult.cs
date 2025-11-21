
namespace Inventory_Atlas.Core.Models
{
    /// <summary>
    /// Объект результата валидации.
    /// </summary>
    public record ValidationResult
    {
        /// <summary>
        /// Флаг результата валидации.
        /// <para/>
        /// Тип: <see langword="bool"/>
        /// </summary>
        public bool IsValid { get; }

        /// <summary>
        /// Сообщение о причине провала валидации.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// </summary>
        public string Error { get; } = string.Empty;

        /// <summary>
        /// Содаёт новый экземпляр <see cref="ValidationResult"/>.
        /// </summary>
        /// <param name="isValid">Флаг результата валидации.</param>
        /// <param name="error">Сообщение о причине провала валидации.</param>
        public ValidationResult(bool isValid, string error = "")
        {
            IsValid = isValid;
            Error = error;
        }
    }
}
