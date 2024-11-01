namespace MyApplication;

public sealed class ConfigSectionIsNullException : Exception
{
    public ConfigSectionIsNullException() { }

    public ConfigSectionIsNullException(string sectionName)
        : base($"Configuration section '{sectionName}' is null.") { }

    public ConfigSectionIsNullException(string message, Exception inner)
        : base(message, inner) { }
}