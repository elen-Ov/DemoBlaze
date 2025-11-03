using Newtonsoft.Json;
using DemoBlaze.Models.ForDefaultUser;

namespace DemoBlaze.Utils;
public static class Config
{
    public static string BaseUrl { get; private set; }
    public static string Username { get; private set; }
    public static string Password { get; private set; }
    public static string Email { get; private set; }
    public static string Name { get; private set; }

    static Config()
    {
        var configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
        if (!File.Exists(configFilePath))
            throw new FileNotFoundException("Config file not found", configFilePath);

        // Чтение и десериализация JSON
        var json = File.ReadAllText(configFilePath);
        var settings = JsonConvert.DeserializeObject<AppSettings>(json);

        BaseUrl = settings.BaseUrl;
        Username = settings.Credentials.Username;
        Password = settings.Credentials.Password;
        Email = settings.Contacts.Email;
        Name = settings.Contacts.Name;
    }
}