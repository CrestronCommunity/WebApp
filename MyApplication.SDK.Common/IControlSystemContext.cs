using Crestron.SimplSharpPro;

namespace MyApplication.SDK.Common;

public interface IControlSystemContext
{
    CrestronControlSystem ControlSystem { get; }
}