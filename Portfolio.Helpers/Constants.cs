namespace Portfolio.Helpers
{
    public static class ConfigPolicy
    {
        public static string Cors = "ClientPermission";
    }

    public static class ConstantsFileService
    {
        // Portfolio - Imagem única - Foto de perfil
        public static string PortfolioProfileImageName = "PortfolioProfile";
        public static string PortfolioProfileEntity = "PortfolioProfile";

        // ContactMe - Arquivo único - Anexo
        public static string ContactMeFileName = "ContactMeFile";
        public static string ContactMeFileEntity = "ContactMeFile";

        // Projects - Imagem única - Imagem de thumb de projeto
        public static string ProjectFileName = "ProjectThumb";
        public static string ProjectFileEntity = "ProjectThumb";

        // Stacks - Imagem única - Imagem de ícone da stack
        public static string StackFileName = "Stacks";
        public static string StackFileEntity = "Stacks";
    }

    public static class ConfigurationTokens
    {
        public static string EmailSmtp = "EMAIL_SMTP";
        public static string EmailPort = "EMAIL_PORT";
        public static string EmailLogin = "EMAIL_LOGIN";
        public static string EmailPass = "EMAIL_PASSWORD";

        public static string AttemptsLoginFailed = "ATTEMPTS_LOGIN_ERROR";
        public static string AttemptsLoginFailedDaysBlock = "ATTEMPTS_LOGIN_ERROR_DAYS_BLOCK";
        public static string TimeExpiresAccessToken = "MINUTES_EXPIRES_ACCESS_TOKEN";
        public static string TimeExpiresRefreshToken = "MINUTES_EXPIRES_REFRESH_TOKEN";
    }

    public static class TokensGenericType
    {
        public static string ExperienceWorkStatus = "EXPERIENCE_WORK_STATUS";
        public static string EducationStatus = "EDUCATION_STATUS";
    }

    public static class DirectoriesName
    {
        public static string EmailTemplates = "Content/Templates";
    }

    public static class ConstantsEmail
    {
        public static string TemplateResetAccount = "ResetPassword.html";
        public static string SubjectResetAccount = $"ALB POrtfolio - Email de redefinição de senha - ";
    }

    public static class ConfigJwt
    {
        public static string AuthenticationScheme = "JwtBearer";
        public static string LoginProviderWeb = "ProviderJwtWeb";
        public static string LoginPurposeWeb = "PurposeJwtWeb";
    }

    public static class ConfigAppSettings
    {
        public static string JwtSecret = "JWT:Secret";
        public static string JwtValidIssuer = "JWT:ValidIssuer";
        public static string JwtValidAudience = "JWT:ValidAudience";
        public static string AuthSection = "Auth";
        public static string JwtSection = "JWT";
        public static string ConnectionPgBManager = "PgSql";
        public static string VersionApi = "VersionAPI";
        public static string ConfigCors = "ConfigCors";
    }
}
