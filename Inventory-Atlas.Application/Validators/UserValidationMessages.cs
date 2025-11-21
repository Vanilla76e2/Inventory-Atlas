namespace Inventory_Atlas.Application.Validators
{
    /// <summary>
    /// Сообщения для ошибок валидации данных профилей пользователей.
    /// </summary>
    internal static class UserValidationMessages
    {
        /// <summary>
        /// Содержит сообщение: <c>Username cannot be empty</c>.
        /// </summary>
        public const string UsernameEmpty = "Username cannot be empty.";

        /// <summary>
        /// Содержит сообщение: <c>Password cannot be empty</c>.
        /// </summary>
        public const string PasswordEmpty = "Password cannot be empty.";

        /// <summary>
        /// Содержит сообщение: <c>Username should be 3 or longer</c>.
        /// </summary>
        public const string UsernameTooShort = "Username should be 3 or longer.";

        /// <summary>
        /// Содержит сообщение: <c>Password should be 8 or longer</c>.
        /// </summary>
        public const string PasswordTooShort = "Password should be 8 or longer.";
    }
}
