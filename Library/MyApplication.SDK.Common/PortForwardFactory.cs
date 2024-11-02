using Crestron.SimplSharp;

namespace MyApplication.SDK.Common;

public static class PortForwardFactory
{
    public static bool TryCreateTcp(params PortForward[] portForwards) => Create("TCP", portForwards);
    public static bool TryCreateUdp(params PortForward[] portForwards) => Create("UDP", portForwards);

    private static bool Create(string type, params PortForward[] portForwards)
    {
        if (!ApplicationEnvironment.HasRouter())
            return false;

        // Note: If you're hosting it from a processor with a control subnet, by default it only listens on the control subnet.
        // To get traffic through to the control subnet, we need to forward the ports. This will NOT work if the processor is
        // in isolation mode.

        var adapterId = CrestronEthernetHelper.GetAdapterdIdForSpecifiedAdapterType(EthernetAdapterType.EthernetCSAdapter);
        var controlSubnetIp = CrestronEthernetHelper.GetEthernetParameter(CrestronEthernetHelper.ETHERNET_PARAMETER_TO_GET.GET_CURRENT_IP_ADDRESS, adapterId);

        foreach (var portForward in portForwards)
            CrestronEthernetHelper.AddPortForwarding((ushort)portForward.ExternalPort, (ushort)portForward.InternalPort, controlSubnetIp, type);

        return true;
    }
}