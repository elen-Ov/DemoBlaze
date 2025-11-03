namespace DemoBlaze.Models;

public class UserContacts
{
    public string ContactEmail { get; set; }
    public string ContactName { get; set; }
    public string Message { get; set; }
    
    public UserContacts(string email, string name, string message)
    {
        ContactEmail = email;
        ContactName = name;
        Message = message;
    }
}