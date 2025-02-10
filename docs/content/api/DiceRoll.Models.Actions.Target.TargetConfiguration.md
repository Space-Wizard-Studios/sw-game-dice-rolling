---
title: Models.Actions.Target.TargetConfiguration
---

# <a id="DiceRoll_Models_Actions_Target_TargetConfiguration"></a> Class TargetConfiguration

Namespace: [DiceRoll.Models.Actions.Target](DiceRoll.Models.Actions.Target.md)  
Assembly: dice\-roll.dll  

```csharp
[Tool]
[GlobalClass]
[ScriptPath("res://models/Action/TargetConfiguration.cs")]
public class TargetConfiguration : Resource, IDisposable
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
GodotObject ← 
RefCounted ← 
Resource ← 
[TargetConfiguration](DiceRoll.Models.Actions.Target.TargetConfiguration.md)

#### Implements

[IDisposable](https://learn.microsoft.com/dotnet/api/system.idisposable)

#### Inherited Members

<details>
<summary>Show/Hide Inherited Members</summary>

Resource.\_GetRid\(\),   
Resource.\_ResetState\(\),   
Resource.\_SetPathCache\(string\),   
Resource.\_SetupLocalToScene\(\),   
Resource.TakeOverPath\(string\),   
Resource.SetPathCache\(string\),   
Resource.GetRid\(\),   
Resource.GetLocalScene\(\),   
Resource.SetupLocalToScene\(\),   
Resource.ResetState\(\),   
Resource.SetIdForPath\(string, string\),   
Resource.GetIdForPath\(string\),   
Resource.IsBuiltIn\(\),   
Resource.GenerateSceneUniqueId\(\),   
Resource.EmitChanged\(\),   
Resource.Duplicate\(bool\),   
Resource.EmitSignalChanged\(\),   
Resource.EmitSignalSetupLocalToSceneRequested\(\),   
Resource.InvokeGodotClassMethod\(in godot\_string\_name, NativeVariantPtrArgs, out godot\_variant\),   
Resource.HasGodotClassMethod\(in godot\_string\_name\),   
Resource.HasGodotClassSignal\(in godot\_string\_name\),   
Resource.ResourceLocalToScene,   
Resource.ResourcePath,   
Resource.ResourceName,   
Resource.ResourceSceneUniqueId,   
Resource.Changed,   
Resource.SetupLocalToSceneRequested,   
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
GodotObject.EmitSignal\(StringName, ReadOnlySpan\<Variant\>\),   
GodotObject.Call\(StringName, params Variant\[\]\),   
GodotObject.Call\(StringName, ReadOnlySpan\<Variant\>\),   
GodotObject.CallDeferred\(StringName, params Variant\[\]\),   
GodotObject.CallDeferred\(StringName, ReadOnlySpan\<Variant\>\),   
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

</details>
## Constructors

### <a id="DiceRoll_Models_Actions_Target_TargetConfiguration__ctor"></a> TargetConfiguration\(\)

```csharp
public TargetConfiguration()
```

## Properties

### <a id="DiceRoll_Models_Actions_Target_TargetConfiguration_Columns"></a> Columns

```csharp
[Export(PropertyHint.None, "")]
public int Columns { get; set; }
```

#### Property Value

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRoll_Models_Actions_Target_TargetConfiguration_Grid"></a> Grid

```csharp
[Export(PropertyHint.None, "")]
public Array<int> Grid { get; set; }
```

#### Property Value

 Array\<[int](https://learn.microsoft.com/dotnet/api/system.int32)\>

### <a id="DiceRoll_Models_Actions_Target_TargetConfiguration_IsSingleTarget"></a> IsSingleTarget

```csharp
[Export(PropertyHint.None, "")]
public bool IsSingleTarget { get; set; }
```

#### Property Value

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

### <a id="DiceRoll_Models_Actions_Target_TargetConfiguration_Rows"></a> Rows

```csharp
[Export(PropertyHint.None, "")]
public int Rows { get; set; }
```

#### Property Value

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

## Methods

### <a id="DiceRoll_Models_Actions_Target_TargetConfiguration_EmitSignalConfigurationChanged"></a> EmitSignalConfigurationChanged\(\)

```csharp
protected void EmitSignalConfigurationChanged()
```

### <a id="DiceRoll_Models_Actions_Target_TargetConfiguration_UpdateGrid"></a> UpdateGrid\(\)

```csharp
public void UpdateGrid()
```

### <a id="DiceRoll_Models_Actions_Target_TargetConfiguration_ConfigurationChanged"></a> ConfigurationChanged

```csharp
public event TargetConfiguration.ConfigurationChangedEventHandler ConfigurationChanged
```

#### Event Type

 [TargetConfiguration](DiceRoll.Models.Actions.Target.TargetConfiguration.md).[ConfigurationChangedEventHandler](DiceRoll.Models.Actions.Target.TargetConfiguration.ConfigurationChangedEventHandler.md)

