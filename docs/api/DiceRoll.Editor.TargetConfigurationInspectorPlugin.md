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
EditorInspectorPlugin.AddPropertyEditor\(string, Control, bool\), 
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
GodotObject.SetGodotClassPropertyValue\(in godot\_string\_name, in godot\_variant\), 
GodotObject.GetGodotClassPropertyValue\(in godot\_string\_name, out godot\_variant\), 
GodotObject.RaiseGodotClassSignalCallbacks\(in godot\_string\_name, NativeVariantPtrArgs\), 
GodotObject.SaveGodotObjectData\(GodotSerializationInfo\), 
GodotObject.RestoreGodotObjectData\(GodotSerializationInfo\), 
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

## Fields

### <a id="DiceRoll_Editor_TargetConfigurationInspectorPlugin_flipCheckBox"></a> flipCheckBox

```csharp
private CheckBox? flipCheckBox
```

#### Field Value

 CheckBox?

### <a id="DiceRoll_Editor_TargetConfigurationInspectorPlugin_matrixControl"></a> matrixControl

```csharp
private MatrixControl? matrixControl
```

#### Field Value

 [MatrixControl](DiceRoll.Editor.MatrixControl.md)?

## Methods

### <a id="DiceRoll_Editor_TargetConfigurationInspectorPlugin_GetGodotClassPropertyValue_Godot_NativeInterop_godot_string_name__Godot_NativeInterop_godot_variant__"></a> GetGodotClassPropertyValue\(in godot\_string\_name, out godot\_variant\)

Get the value of a property contained in this class.
This method is used by Godot to retrieve property values.
Do not call or override this method.

```csharp
[EditorBrowsable(EditorBrowsableState.Never)]
protected override bool GetGodotClassPropertyValue(in godot_string_name name, out godot_variant value)
```

#### Parameters

`name` godot\_string\_name

Name of the property to get.

`value` godot\_variant

Value of the property if it was found.

#### Returns

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

<a href="https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool">true</a> if a property with the given name was found.

### <a id="DiceRoll_Editor_TargetConfigurationInspectorPlugin_GetGodotMethodList"></a> GetGodotMethodList\(\)

Get the method information for all the methods declared in this class.
This method is used by Godot to register the available methods in the editor.
Do not call this method.

```csharp
[EditorBrowsable(EditorBrowsableState.Never)]
internal static List<MethodInfo> GetGodotMethodList()
```

#### Returns

 [List](https://learn.microsoft.com/dotnet/api/system.collections.generic.list\-1)<MethodInfo\>

### <a id="DiceRoll_Editor_TargetConfigurationInspectorPlugin_GetGodotPropertyList"></a> GetGodotPropertyList\(\)

Get the property information for all the properties declared in this class.
This method is used by Godot to register the available properties in the editor.
Do not call this method.

```csharp
[EditorBrowsable(EditorBrowsableState.Never)]
internal static List<PropertyInfo> GetGodotPropertyList()
```

#### Returns

 [List](https://learn.microsoft.com/dotnet/api/system.collections.generic.list\-1)<PropertyInfo\>

### <a id="DiceRoll_Editor_TargetConfigurationInspectorPlugin_HasGodotClassMethod_Godot_NativeInterop_godot_string_name__"></a> HasGodotClassMethod\(in godot\_string\_name\)

Check if the type contains a method with the given name.
This method is used by Godot to check if a method exists before invoking it.
Do not call or override this method.

```csharp
[EditorBrowsable(EditorBrowsableState.Never)]
protected override bool HasGodotClassMethod(in godot_string_name method)
```

#### Parameters

`method` godot\_string\_name

Name of the method to check for.

#### Returns

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

### <a id="DiceRoll_Editor_TargetConfigurationInspectorPlugin_InvokeGodotClassMethod_Godot_NativeInterop_godot_string_name__Godot_NativeInterop_NativeVariantPtrArgs_Godot_NativeInterop_godot_variant__"></a> InvokeGodotClassMethod\(in godot\_string\_name, NativeVariantPtrArgs, out godot\_variant\)

Invokes the method with the given name, using the given arguments.
This method is used by Godot to invoke methods from the engine side.
Do not call or override this method.

```csharp
[EditorBrowsable(EditorBrowsableState.Never)]
protected override bool InvokeGodotClassMethod(in godot_string_name method, NativeVariantPtrArgs args, out godot_variant ret)
```

#### Parameters

`method` godot\_string\_name

Name of the method to invoke.

`args` NativeVariantPtrArgs

Arguments to use with the invoked method.

`ret` godot\_variant

Value returned by the invoked method.

#### Returns

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

### <a id="DiceRoll_Editor_TargetConfigurationInspectorPlugin_OnConfigurationChanged"></a> OnConfigurationChanged\(\)

```csharp
private void OnConfigurationChanged()
```

### <a id="DiceRoll_Editor_TargetConfigurationInspectorPlugin_OnFlipCheckBoxToggled_System_Boolean_"></a> OnFlipCheckBoxToggled\(bool\)

```csharp
private void OnFlipCheckBoxToggled(bool buttonPressed)
```

#### Parameters

`buttonPressed` [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

### <a id="DiceRoll_Editor_TargetConfigurationInspectorPlugin_RestoreGodotObjectData_Godot_Bridge_GodotSerializationInfo_"></a> RestoreGodotObjectData\(GodotSerializationInfo\)

Restores this instance's state after reloading assemblies.
Do not call or override this method.
To add data to be saved and restored, implement <xref href="Godot.ISerializationListener" data-throw-if-not-resolved="false"></xref>.

```csharp
[EditorBrowsable(EditorBrowsableState.Never)]
protected override void RestoreGodotObjectData(GodotSerializationInfo info)
```

#### Parameters

`info` GodotSerializationInfo

Object that contains the previously saved data.

### <a id="DiceRoll_Editor_TargetConfigurationInspectorPlugin_SaveGodotObjectData_Godot_Bridge_GodotSerializationInfo_"></a> SaveGodotObjectData\(GodotSerializationInfo\)

Saves this instance's state to be restored when reloading assemblies.
Do not call or override this method.
To add data to be saved and restored, implement <xref href="Godot.ISerializationListener" data-throw-if-not-resolved="false"></xref>.

```csharp
[EditorBrowsable(EditorBrowsableState.Never)]
protected override void SaveGodotObjectData(GodotSerializationInfo info)
```

#### Parameters

`info` GodotSerializationInfo

Object used to save the data.

### <a id="DiceRoll_Editor_TargetConfigurationInspectorPlugin_SetGodotClassPropertyValue_Godot_NativeInterop_godot_string_name__Godot_NativeInterop_godot_variant__"></a> SetGodotClassPropertyValue\(in godot\_string\_name, in godot\_variant\)

Set the value of a property contained in this class.
This method is used by Godot to assign property values.
Do not call or override this method.

```csharp
[EditorBrowsable(EditorBrowsableState.Never)]
protected override bool SetGodotClassPropertyValue(in godot_string_name name, in godot_variant value)
```

#### Parameters

`name` godot\_string\_name

Name of the property to set.

`value` godot\_variant

Value to set the property to if it was found.

#### Returns

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

<a href="https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool">true</a> if a property with the given name was found.

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

