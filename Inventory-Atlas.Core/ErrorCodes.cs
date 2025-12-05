namespace Inventory_Atlas.Core
{
    public static class ErrorCodes
    {
        // System
        public const string UnexpectedError = "System.UnexpextedError";

        // User
        public const string UsernameAlreadtExists = "User.UsernameAlreadyExists";
        public const string InvalidUsername = "User.InvalidUsername";
        public const string UsernameTooShort = "User.UsernameTooShort";
        public const string InvalidPassword = "User.InvalidPassword";
        public const string PasswordTooShort = "User.PasswordTooShort";
        public const string UserNotExist = "User.NotExist";
        public const string InvalidEmployeeId = "User.InvalidEmployeeId";
        public const string InvalidRoleId = "User.InvalidRoleId";

        // Auth
        public const string AuthMissingCredentials = "Auth.MissingCredetials";
        public const string AuthInvalidCredentials = "Auth.InvalidCredetials";
        public const string AuthUserInactive = "Auth.UserInactive";
    }
}
