namespace DemoBlaze.Utils;

public class StringUtils
{
    public static string GenerateRandomString(int length)
    {
        var random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        return new string(
            Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    
    public static (string Name, string Password) GenerateUserNameAndPassword(int length)
    {
        string random = GenerateRandomString(length);
        return ("name_" + random, "password_" + random);
    }
}