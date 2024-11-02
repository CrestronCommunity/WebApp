namespace MyApplication.SDK.Common;

public sealed class PortForward
{
    /// <summary>
    /// External port.
    /// </summary>
    public int ExternalPort { get; }

    /// <summary>
    /// Internal port.
    /// </summary>
    public int InternalPort { get; }

    public PortForward(int internalPort, int? externalPort = null)
    {
        InternalPort = internalPort;
        ExternalPort = externalPort ?? internalPort;
    }
}