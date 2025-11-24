namespace Inventory_Atlas.Core
{
    public static class ErrorCodes
    {
        // System
        public const string UnexpectedError = "System.UnexpextedError";

        // User
        public const string UsernameAlreadtExists = "User.UsernameAlreadyExists";
        public const string UsernameInvalid = "User.InvalidUsername";
        public const string UsernameTooShort = "User.UsernameTooShort";
        public const string PasswordInvalid = "User.InvalidPassword";
        public const string PasswordTooShort = "User.PasswordTooShort";
        public const string UserNotExist = "User.NotExist";
    }
}
