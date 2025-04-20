namespace WebStackBase.Application.Configuration;

public class SmtpSettings
{
    public string Host { get; set; } = null!;
    public int Port { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string From { get; set; } = null!;
    public string DisplayName { get; set; } = null!;
    public bool EnableSsl { get; set; }
}