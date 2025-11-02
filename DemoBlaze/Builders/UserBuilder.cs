using DemoBlaze.Models;

namespace DemoBlaze.Builders;

public class UserBuilder
{
    private string? _username;
    private string? _password;
    
    public UserBuilder WithUsername(string username)
    {
        _username = username;
        return this;
    }

    public UserBuilder WithPassword(string password)
    {
        _password = password;
        return this;
    }

    public User Build()
    {
        return new User(_username, _password);
    }
}