# <a id="DiceRoll_Editor_TargetConfigurationInspectorPlugin"></a> Class TargetConfigurationInspectorPlugin

Namespace: [DiceRoll.Editor](DiceRoll.Editor.md)  
Assembly: dice\-roll.dll  

Custom inspector plugin for handling TargetConfiguration objects in the Godot Editor.

```csharp
[ScriptPath("res://addons/TargetConfigurationEditorPlugin/TargetConfigurationInspectorPlugin.cs")]
public class TargetConfigurationInspectorPlugin : EditorInspectorPlugin, IDisposable
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
GodotObject ← 
RefCounted ← 
EditorInspectorPlugin ← 
[TargetConfigurationInspectorPlugin](DiceRoll.Editor.TargetConfigurationInspectorPlugin.md)

#### Implements

[IDisposable](https://learn.microsoft.com/dotnet/api/system.idisposable)

#### Inherited Members

EditorInspectorPlugin.\_CanHandle\(GodotObject\), 
EditorInspectorPlugin.\_ParseBegin\(GodotObject\), 
EditorInspectorPlugin.\_ParseCategory\(GodotObject, string\), 
EditorInspectorPlugin.\_ParseEnd\(GodotObject\), 
EditorInspectorPlugin.\_ParseGroup\(GodotObject, string\), 
EditorInspectorPlugin.\_ParseProperty\(GodotObject, Variant.Type, string, PropertyHint, string, PropertyUsageFlags, bool\), 
EditorInspectorPlugin.AddCustomControl\(Control\), 
EditorInspectorPlugin.AddPropertyEditor\(string, Control, bool, string\), 
EditorInspectorPlugin.AddPropertyEditorForMultipleProperties\(string, string\[\], Control\), 
EditorInspectorPlugin.AddPropertyEditorForMultipleProperties\(string, ReadOnlySpan<string\>, Control\), 
EditorInspectorPlugin.InvokeGodotClassMethod\(in godot\_string\_name, NativeVariantPtrArgs, out godot\_variant\), 
EditorInspectorPlugin.HasGodotClassMethod\(in godot\_string\_name\), 
EditorInspectorPlugin.HasGodotClassSignal\(in godot\_string\_name\), 
RefCounted.InitRef\(\), 
RefCounted.Reference\(\), 
RefCounted.Unreference\(\), 
RefCounted.GetReferenceCount\(\), 
RefCounted.InvokeGodotClassMethod\(in godot\_string\_name, NativeVariantPtrArgs, out godot\_variant\), 
RefCounted.HasGodotClassMethod\(in godot\_string\_name\), 
RefCounted.HasGodotClassSignal\(in godot\_string\_name\), 
GodotObject.NotificationPostinitialize, 
GodotObject.NotificationPredelete, 
GodotObject.NotificationExtensionReloaded, 
GodotObject.InstanceFromId\(ulong\), 
GodotObject.IsInstanceIdValid\(ulong\), 
GodotObject.IsInstanceValid\(GodotObject?\), 
GodotObject.WeakRef\(GodotObject?\), 
GodotObject.Dispose\(\), 
GodotObject.Dispose\(bool\), 
GodotObject.ToString\(\), 
GodotObject.ToSignal\(GodotObject, StringName\), 
GodotObject.\_Get\(StringName\), 
GodotObject.\_GetPropertyList\(\), 
GodotObject.\_IterGet\(Variant\), 
GodotObject.\_IterInit\(Array\), 
GodotObject.\_IterNext\(Array\), 
GodotObject.\_Notification\(int\), 
GodotObject.\_PropertyCanRevert\(StringName\), 
GodotObject.\_PropertyGetRevert\(StringName\), 
GodotObject.\_Set\(StringName, Variant\), 
GodotObject.\_ValidateProperty\(Dictionary\), 
GodotObject.Free\(\), 
GodotObject.GetClass\(\), 
GodotObject.IsClass\(string\), 
GodotObject.Set\(StringName, Variant\), 
GodotObject.Get\(StringName\), 
GodotObject.SetIndexed\(NodePath, Variant\), 
GodotObject.GetIndexed\(NodePath\), 
GodotObject.GetPropertyList\(\), 
GodotObject.GetMethodList\(\), 
GodotObject.PropertyCanRevert\(StringName\), 
GodotObject.PropertyGetRevert\(StringName\), 
GodotObject.Notification\(int, bool\), 
GodotObject.GetInstanceId\(\), 
GodotObject.SetScript\(Variant\), 
GodotObject.GetScript\(\), 
GodotObject.SetMeta\(StringName, Variant\), 
GodotObject.RemoveMeta\(StringName\), 
GodotObject.GetMeta\(StringName, Variant\), 
GodotObject.HasMeta\(StringName\), 
GodotObject.GetMetaList\(\), 
GodotObject.AddUserSignal\(string, Array\), 
GodotObject.HasUserSignal\(StringName\), 
GodotObject.RemoveUserSignal\(StringName\), 
GodotObject.EmitSignal\(StringName, params Variant\[\]\), 
GodotObject.EmitSignal\(StringName, ReadOnlySpan<Variant\>\), 
GodotObject.Call\(StringName, params Variant\[\]\), 
GodotObject.Call\(StringName, ReadOnlySpan<Variant\>\), 
GodotObject.CallDeferred\(StringName, params Variant\[\]\), 
GodotObject.CallDeferred\(StringName, ReadOnlySpan<Variant\>\), 
GodotObject.SetDeferred\(StringName, Variant\), 
GodotObject.Callv\(StringName, Array\), 
GodotObject.HasMethod\(StringName\), 
GodotObject.GetMethodArgumentCount\(StringName\), 
GodotObject.HasSignal\(StringName\), 
GodotObject.GetSignalList\(\), 
GodotObject.GetSignalConnectionList\(StringName\), 
GodotObject.GetIncomingConnections\(\), 
GodotObject.Connect\(StringName, Callable, uint\), 
GodotObject.Disconnect\(StringName, Callable\), 
GodotObject.IsConnected\(StringName, Callable\), 
GodotObject.HasConnections\(StringName\), 
GodotObject.SetBlockSignals\(bool\), 
GodotObject.IsBlockingSignals\(\), 
GodotObject.NotifyPropertyListChanged\(\), 
GodotObject.SetMessageTranslation\(bool\), 
GodotObject.CanTranslateMessages\(\), 
GodotObject.Tr\(StringName, StringName\), 
GodotObject.TrN\(StringName, StringName, int, StringName\), 
GodotObject.GetTranslationDomain\(\), 
GodotObject.SetTranslationDomain\(StringName\), 
GodotObject.IsQueuedForDeletion\(\), 
GodotObject.CancelFree\(\), 
GodotObject.EmitSignalScriptChanged\(\), 
GodotObject.EmitSignalPropertyListChanged\(\), 
GodotObject.InvokeGodotClassMethod\(in godot\_string\_name, NativeVariantPtrArgs, out godot\_variant\), 
GodotObject.HasGodotClassMethod\(in godot\_string\_name\), 
GodotObject.HasGodotClassSignal\(in godot\_string\_name\), 
GodotObject.NativeInstance, 
GodotObject.ScriptChanged, 
GodotObject.PropertyListChanged, 
[object.Equals\(object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\)), 
[object.Equals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\-system\-object\)), 
[object.GetHashCode\(\)](https://learn.microsoft.com/dotnet/api/system.object.gethashcode), 
[object.GetType\(\)](https://learn.microsoft.com/dotnet/api/system.object.gettype), 
[object.MemberwiseClone\(\)](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone), 
[object.ReferenceEquals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals), 
[object.ToString\(\)](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Methods

### <a id="DiceRoll_Editor_TargetConfigurationInspectorPlugin__CanHandle_Godot_GodotObject_"></a> \_CanHandle\(GodotObject\)

Determines if the plugin can handle the given object.

```csharp
public override bool _CanHandle(GodotObject @object)
```

#### Parameters

`object` GodotObject

The object to check.

#### Returns

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

True if the object is a TargetConfiguration, otherwise false.

### <a id="DiceRoll_Editor_TargetConfigurationInspectorPlugin__ParseBegin_Godot_GodotObject_"></a> \_ParseBegin\(GodotObject\)

Initializes custom controls for the TargetConfiguration object.

```csharp
public override void _ParseBegin(GodotObject @object)
```

#### Parameters

`object` GodotObject

The TargetConfiguration object.

### <a id="DiceRoll_Editor_TargetConfigurationInspectorPlugin__ParseEnd_Godot_GodotObject_"></a> \_ParseEnd\(GodotObject\)

<p>Called to allow adding controls at the end of the property list for <code class="paramref">object</code>.</p>

```csharp
public override void _ParseEnd(GodotObject @object)
```

#### Parameters

`object` GodotObject

