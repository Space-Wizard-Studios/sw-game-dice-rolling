using Godot;

namespace DiceRolling.Helpers;

/// <summary>
/// Helper class for safely connecting and disconnecting signals in Godot
/// </summary>
public static class SignalHelper {
    public static void ConnectSignal(GodotObject? source, string signalName, GodotObject target, string methodName) {
        if (source == null)
            return;

        if (!source.HasSignal(signalName)) {
            GD.PushWarning($"Object of type {source.GetType()} does not have signal '{signalName}'");
            return;
        }

        // Check if the signal is already connected to avoid duplicates
        if (source.IsConnected(signalName, new Callable(target, methodName)))
            return;

        source.Connect(signalName, new Callable(target, methodName));
    }

    public static void DisconnectSignal(GodotObject? source, string signalName, GodotObject target, string methodName) {
        if (source == null)
            return;

        if (!source.HasSignal(signalName))
            return;

        // Only disconnect if the signal is actually connected
        if (source.IsConnected(signalName, new Callable(target, methodName)))
            source.Disconnect(signalName, new Callable(target, methodName));
    }
}