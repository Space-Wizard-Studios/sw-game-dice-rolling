using Godot;

namespace DiceRolling.Helpers;

/// <summary>
/// Helper class for safely connecting and disconnecting signals in Godot
/// </summary>
public static class SignalHelper {
    /// <summary>
    /// Safely connects a signal from a source object to a target method
    /// </summary>
    /// <param name="source">The source object that emits the signal</param>
    /// <param name="signalName">Name of the signal to connect</param>
    /// <param name="target">The target object that will receive the signal</param>
    /// <param name="methodName">Name of the method to call when the signal is emitted</param>
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

    /// <summary>
    /// Safely disconnects a signal from a source object
    /// </summary>
    /// <param name="source">The source object that emits the signal</param>
    /// <param name="signalName">Name of the signal to disconnect</param>
    /// <param name="target">The target object that was receiving the signal</param>
    /// <param name="methodName">Name of the method that was called when the signal was emitted</param>
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