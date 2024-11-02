using Crestron.SimplSharpPro;

namespace MyApplication.SDK.Common;

public sealed class ControlSystemContext : IControlSystemContext
{
    public CrestronControlSystem ControlSystem { get; }

    public ControlSystemContext(CrestronControlSystem controlSystem)
    {
        ControlSystem = controlSystem;
    }
}