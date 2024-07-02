namespace Krugozor.Models
{
    public class MailSettings
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Host { get; set; }
        public int Port { get; set; }
        public bool UseSSL { get; set; }
        public bool UseStartTls { get; set; }
        public bool UseOAuth { get; set; }
    }
}
