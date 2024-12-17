namespace BadLibrary;

using SDK;

public class BadClass : ISettingsProvider
{
    public string Get(string path)
    {
        // TODO: something evil
        return string.Empty;
    }
}
