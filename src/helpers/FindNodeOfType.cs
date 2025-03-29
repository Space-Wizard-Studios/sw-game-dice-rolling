using Godot;

namespace DiceRolling.Helpers;

/// <summary>
/// Provides extension methods for Godot Node operations
/// </summary>
public static class NodeExtensions {
    /// <summary>
    /// Recursively searches for a node of the specified type starting from the given root node
    /// </summary>
    /// <typeparam name="T">The type of node to find</typeparam>
    /// <param name="root">The root node to start searching from</param>
    /// <returns>The first node of type T found, or null if none exists</returns>
    public static T? FindNodeOfType<T>(this Node root) where T : class {
        if (root is T nodeOfType) {
            GD.Print($"Found node of type {typeof(T)}: {nodeOfType}");
            return nodeOfType;
        }

        foreach (Node child in root.GetChildren()) {
            GD.Print($"Searching in child node: {child}");
            var result = FindNodeOfType<T>(child);
            if (result != null) {
                return result;
            }
        }

        return null;
    }
}