# <a id="DiceRoll_Editor_Arc3DGizmoPlugin"></a> Class Arc3DGizmoPlugin

Namespace: [DiceRoll.Editor](DiceRoll.Editor.md)  
Assembly: dice\-roll.dll  

A plugin for rendering 3D gizmos in the editor for Arc3DRenderer nodes.

```csharp
[Tool]
[ScriptPath("res://addons/@spacewiz/Arc3DEditorPlugin/Arc3DGizmoPlugin.cs")]
public class Arc3DGizmoPlugin : EditorNode3DGizmoPlugin, IDisposable
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
GodotObject ← 
RefCounted ← 
Resource ← 
EditorNode3DGizmoPlugin ← 
[Arc3DGizmoPlugin](DiceRoll.Editor.Arc3DGizmoPlugin.md)

#### Implements

[IDisposable](https://learn.microsoft.com/dotnet/api/system.idisposable)

#### Inherited Members

EditorNode3DGizmoPlugin.\_BeginHandleAction\(EditorNode3DGizmo, int, bool\), 
EditorNode3DGizmoPlugin.\_CanBeHidden\(\), 
EditorNode3DGizmoPlugin.\_CommitHandle\(EditorNode3DGizmo, int, bool, Variant, bool\), 
EditorNode3DGizmoPlugin.\_CommitSubgizmos\(EditorNode3DGizmo, int\[\], Array<Transform3D\>, bool\), 
EditorNode3DGizmoPlugin.\_CreateGizmo\(Node3D\), 
EditorNode3DGizmoPlugin.\_GetGizmoName\(\), 
EditorNode3DGizmoPlugin.\_GetHandleName\(EditorNode3DGizmo, int, bool\), 
EditorNode3DGizmoPlugin.\_GetHandleValue\(EditorNode3DGizmo, int, bool\), 
EditorNode3DGizmoPlugin.\_GetPriority\(\), 
EditorNode3DGizmoPlugin.\_GetSubgizmoTransform\(EditorNode3DGizmo, int\), 
EditorNode3DGizmoPlugin.\_HasGizmo\(Node3D\), 
EditorNode3DGizmoPlugin.\_IsHandleHighlighted\(EditorNode3DGizmo, int, bool\), 
EditorNode3DGizmoPlugin.\_IsSelectableWhenHidden\(\), 
EditorNode3DGizmoPlugin.\_Redraw\(EditorNode3DGizmo\), 
EditorNode3DGizmoPlugin.\_SetHandle\(EditorNode3DGizmo, int, bool, Camera3D, Vector2\), 
EditorNode3DGizmoPlugin.\_SetSubgizmoTransform\(EditorNode3DGizmo, int, Transform3D\), 
EditorNode3DGizmoPlugin.\_SubgizmosIntersectFrustum\(EditorNode3DGizmo, Camera3D, Array<Plane\>\), 
EditorNode3DGizmoPlugin.\_SubgizmosIntersectRay\(EditorNode3DGizmo, Camera3D, Vector2\), 
EditorNode3DGizmoPlugin.CreateMaterial\(string, Color, bool, bool, bool\), 
EditorNode3DGizmoPlugin.CreateIconMaterial\(string, Texture2D, bool, Color?\), 
EditorNode3DGizmoPlugin.CreateHandleMaterial\(string, bool, Texture2D\), 
EditorNode3DGizmoPlugin.AddMaterial\(string, StandardMaterial3D\), 
EditorNode3DGizmoPlugin.GetMaterial\(string, EditorNode3DGizmo\), 
EditorNode3DGizmoPlugin.InvokeGodotClassMethod\(in godot\_string\_name, NativeVariantPtrArgs, out godot\_variant\), 
EditorNode3DGizmoPlugin.HasGodotClassMethod\(in godot\_string\_name\), 
EditorNode3DGizmoPlugin.HasGodotClassSignal\(in godot\_string\_name\), 
Resource.\_GetRid\(\), 
Resource.\_ResetState\(\), 
Resource.\_SetPathCache\(string\), 
Resource.\_SetupLocalToScene\(\), 
Resource.SetPath\(string\), 
Resource.TakeOverPath\(string\), 
Resource.GetPath\(\), 
Resource.SetPathCache\(string\), 
Resource.SetName\(string\), 
Resource.GetName\(\), 
Resource.GetRid\(\), 
Resource.SetLocalToScene\(bool\), 
Resource.IsLocalToScene\(\), 
Resource.GetLocalScene\(\), 
Resource.SetupLocalToScene\(\), 
Resource.ResetState\(\), 
Resource.SetIdForPath\(string, string\), 
Resource.GetIdForPath\(string\), 
Resource.IsBuiltIn\(\), 
Resource.GenerateSceneUniqueId\(\), 
Resource.SetSceneUniqueId\(string\), 
Resource.GetSceneUniqueId\(\), 
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

## Constructors

### <a id="DiceRoll_Editor_Arc3DGizmoPlugin__ctor"></a> Arc3DGizmoPlugin\(\)

Initializes a new instance of the <xref href="DiceRoll.Editor.Arc3DGizmoPlugin" data-throw-if-not-resolved="false"></xref> class.

```csharp
public Arc3DGizmoPlugin()
```

## Methods

### <a id="DiceRoll_Editor_Arc3DGizmoPlugin_GetGodotClassPropertyValue_Godot_NativeInterop_godot_string_name__Godot_NativeInterop_godot_variant__"></a> GetGodotClassPropertyValue\(in godot\_string\_name, out godot\_variant\)

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

### <a id="DiceRoll_Editor_Arc3DGizmoPlugin_HasGodotClassMethod_Godot_NativeInterop_godot_string_name__"></a> HasGodotClassMethod\(in godot\_string\_name\)

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

### <a id="DiceRoll_Editor_Arc3DGizmoPlugin_InvokeGodotClassMethod_Godot_NativeInterop_godot_string_name__Godot_NativeInterop_NativeVariantPtrArgs_Godot_NativeInterop_godot_variant__"></a> InvokeGodotClassMethod\(in godot\_string\_name, NativeVariantPtrArgs, out godot\_variant\)

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

### <a id="DiceRoll_Editor_Arc3DGizmoPlugin_RestoreGodotObjectData_Godot_Bridge_GodotSerializationInfo_"></a> RestoreGodotObjectData\(GodotSerializationInfo\)

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

### <a id="DiceRoll_Editor_Arc3DGizmoPlugin_SaveGodotObjectData_Godot_Bridge_GodotSerializationInfo_"></a> SaveGodotObjectData\(GodotSerializationInfo\)

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

### <a id="DiceRoll_Editor_Arc3DGizmoPlugin__GetGizmoName"></a> \_GetGizmoName\(\)

Gets the name of the gizmo.

        <p>Override this method to provide the name that will appear in the gizmo visibility menu.</p>

```csharp
public override string _GetGizmoName()
```

#### Returns

 [string](https://learn.microsoft.com/dotnet/api/system.string)

The name of the gizmo.

### <a id="DiceRoll_Editor_Arc3DGizmoPlugin__HasGizmo_Godot_Node3D_"></a> \_HasGizmo\(Node3D\)

Determines whether the specified node has a gizmo.

        <p>Override this method to define which Node3D nodes have a gizmo from this plugin. Whenever a <xref href="Godot.Node3D" data-throw-if-not-resolved="false"></xref> node is added to a scene this method is called, if it returns <a href="https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/bool">true</a> the node gets a generic <xref href="Godot.EditorNode3DGizmo" data-throw-if-not-resolved="false"></xref> assigned and is added to this plugin's list of active gizmos.</p>

```csharp
public override bool _HasGizmo(Node3D node)
```

#### Parameters

`node` Node3D

The node to check.

#### Returns

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

<code>true</code> if the node has a gizmo; otherwise, <code>false</code>.

### <a id="DiceRoll_Editor_Arc3DGizmoPlugin__Redraw_Godot_EditorNode3DGizmo_"></a> \_Redraw\(EditorNode3DGizmo\)

Redraws the gizmo for the specified <xref href="Godot.EditorNode3DGizmo" data-throw-if-not-resolved="false"></xref>.

        <p>Override this method to add all the gizmo elements whenever a gizmo update is requested. It's common to call <xref href="Godot.EditorNode3DGizmo.Clear" data-throw-if-not-resolved="false"></xref> at the beginning of this method and then add visual elements depending on the node's properties.</p>

```csharp
public override void _Redraw(EditorNode3DGizmo gizmo)
```

#### Parameters

`gizmo` EditorNode3DGizmo

The gizmo to redraw.

