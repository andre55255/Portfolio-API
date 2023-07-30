namespace Portfolio.Communication.ViewObjects.Utlis
{
    public class APISettingsVO
    {
        public string[] CorsUrls { get; set; }
        public JwtSettingsVO? Jwt { get; set; } = null;
        public AuthSettingsVO? Auth { get; set; } = null;
        public string? VersionAPI { get; set; } = null;
    }

    public class JwtSettingsVO
    {
        public string? ValidIssuer { get; set; }
        public string? ValidAudience { get; set; }
        public string? Secret { get; set; }
    }

    public class AuthSettingsVO
    {
        public int? AttemptsLoginError { get; set; }
        public int? AttemptsLoginFailedDaysBlock { get; set; }
        public int? TimeMinExpiresAccessToken { get; set; }
        public int? TimeMinExpiresRefreshToken { get; set; }
    }
}
