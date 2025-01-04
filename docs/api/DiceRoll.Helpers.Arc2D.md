# <a id="DiceRoll_Helpers_Arc2D"></a> Class Arc2D

Namespace: [DiceRoll.Helpers](DiceRoll.Helpers.md)  
Assembly: dice\-roll.dll  

```csharp
[Tool]
[ScriptPath("res://helpers/Arc2D.cs")]
public class Arc2D : Line2D, IDisposable
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
GodotObject ← 
Node ← 
CanvasItem ← 
Node2D ← 
Line2D ← 
[Arc2D](DiceRoll.Helpers.Arc2D.md)

#### Implements

[IDisposable](https://learn.microsoft.com/dotnet/api/system.idisposable)

#### Inherited Members

Line2D.SetPoints\(Vector2\[\]\), 
Line2D.SetPoints\(ReadOnlySpan<Vector2\>\), 
Line2D.GetPoints\(\), 
Line2D.SetPointPosition\(int, Vector2\), 
Line2D.GetPointPosition\(int\), 
Line2D.GetPointCount\(\), 
Line2D.AddPoint\(Vector2, int\), 
Line2D.RemovePoint\(int\), 
Line2D.ClearPoints\(\), 
Line2D.SetClosed\(bool\), 
Line2D.IsClosed\(\), 
Line2D.SetWidth\(float\), 
Line2D.GetWidth\(\), 
Line2D.SetCurve\(Curve\), 
Line2D.GetCurve\(\), 
Line2D.SetDefaultColor\(Color\), 
Line2D.GetDefaultColor\(\), 
Line2D.SetGradient\(Gradient\), 
Line2D.GetGradient\(\), 
Line2D.SetTexture\(Texture2D\), 
Line2D.GetTexture\(\), 
Line2D.SetTextureMode\(Line2D.LineTextureMode\), 
Line2D.GetTextureMode\(\), 
Line2D.SetJointMode\(Line2D.LineJointMode\), 
Line2D.GetJointMode\(\), 
Line2D.SetBeginCapMode\(Line2D.LineCapMode\), 
Line2D.GetBeginCapMode\(\), 
Line2D.SetEndCapMode\(Line2D.LineCapMode\), 
Line2D.GetEndCapMode\(\), 
Line2D.SetSharpLimit\(float\), 
Line2D.GetSharpLimit\(\), 
Line2D.SetRoundPrecision\(int\), 
Line2D.GetRoundPrecision\(\), 
Line2D.SetAntialiased\(bool\), 
Line2D.GetAntialiased\(\), 
Line2D.InvokeGodotClassMethod\(in godot\_string\_name, NativeVariantPtrArgs, out godot\_variant\), 
Line2D.HasGodotClassMethod\(in godot\_string\_name\), 
Line2D.HasGodotClassSignal\(in godot\_string\_name\), 
Line2D.Points, 
Line2D.Closed, 
Line2D.Width, 
Line2D.WidthCurve, 
Line2D.DefaultColor, 
Line2D.Gradient, 
Line2D.Texture, 
Line2D.TextureMode, 
Line2D.JointMode, 
Line2D.BeginCapMode, 
Line2D.EndCapMode, 
Line2D.SharpLimit, 
Line2D.RoundPrecision, 
Line2D.Antialiased, 
Node2D.SetPosition\(Vector2\), 
Node2D.SetRotation\(float\), 
Node2D.SetRotationDegrees\(float\), 
Node2D.SetSkew\(float\), 
Node2D.SetScale\(Vector2\), 
Node2D.GetPosition\(\), 
Node2D.GetRotation\(\), 
Node2D.GetRotationDegrees\(\), 
Node2D.GetSkew\(\), 
Node2D.GetScale\(\), 
Node2D.Rotate\(float\), 
Node2D.MoveLocalX\(float, bool\), 
Node2D.MoveLocalY\(float, bool\), 
Node2D.Translate\(Vector2\), 
Node2D.GlobalTranslate\(Vector2\), 
Node2D.ApplyScale\(Vector2\), 
Node2D.SetGlobalPosition\(Vector2\), 
Node2D.GetGlobalPosition\(\), 
Node2D.SetGlobalRotation\(float\), 
Node2D.SetGlobalRotationDegrees\(float\), 
Node2D.GetGlobalRotation\(\), 
Node2D.GetGlobalRotationDegrees\(\), 
Node2D.SetGlobalSkew\(float\), 
Node2D.GetGlobalSkew\(\), 
Node2D.SetGlobalScale\(Vector2\), 
Node2D.GetGlobalScale\(\), 
Node2D.SetTransform\(Transform2D\), 
Node2D.SetGlobalTransform\(Transform2D\), 
Node2D.LookAt\(Vector2\), 
Node2D.GetAngleTo\(Vector2\), 
Node2D.ToLocal\(Vector2\), 
Node2D.ToGlobal\(Vector2\), 
Node2D.GetRelativeTransformToParent\(Node\), 
Node2D.InvokeGodotClassMethod\(in godot\_string\_name, NativeVariantPtrArgs, out godot\_variant\), 
Node2D.HasGodotClassMethod\(in godot\_string\_name\), 
Node2D.HasGodotClassSignal\(in godot\_string\_name\), 
Node2D.Position, 
Node2D.Rotation, 
Node2D.RotationDegrees, 
Node2D.Scale, 
Node2D.Skew, 
Node2D.Transform, 
Node2D.GlobalPosition, 
Node2D.GlobalRotation, 
Node2D.GlobalRotationDegrees, 
Node2D.GlobalScale, 
Node2D.GlobalSkew, 
Node2D.GlobalTransform, 
CanvasItem.NotificationTransformChanged, 
CanvasItem.NotificationLocalTransformChanged, 
CanvasItem.NotificationDraw, 
CanvasItem.NotificationVisibilityChanged, 
CanvasItem.NotificationEnterCanvas, 
CanvasItem.NotificationExitCanvas, 
CanvasItem.NotificationWorld2DChanged, 
CanvasItem.\_Draw\(\), 
CanvasItem.GetCanvasItem\(\), 
CanvasItem.SetVisible\(bool\), 
CanvasItem.IsVisible\(\), 
CanvasItem.IsVisibleInTree\(\), 
CanvasItem.Show\(\), 
CanvasItem.Hide\(\), 
CanvasItem.QueueRedraw\(\), 
CanvasItem.MoveToFront\(\), 
CanvasItem.SetAsTopLevel\(bool\), 
CanvasItem.IsSetAsTopLevel\(\), 
CanvasItem.SetLightMask\(int\), 
CanvasItem.GetLightMask\(\), 
CanvasItem.SetModulate\(Color\), 
CanvasItem.GetModulate\(\), 
CanvasItem.SetSelfModulate\(Color\), 
CanvasItem.GetSelfModulate\(\), 
CanvasItem.SetZIndex\(int\), 
CanvasItem.GetZIndex\(\), 
CanvasItem.SetZAsRelative\(bool\), 
CanvasItem.IsZRelative\(\), 
CanvasItem.SetYSortEnabled\(bool\), 
CanvasItem.IsYSortEnabled\(\), 
CanvasItem.SetDrawBehindParent\(bool\), 
CanvasItem.IsDrawBehindParentEnabled\(\), 
CanvasItem.DrawLine\(Vector2, Vector2, Color, float, bool\), 
CanvasItem.DrawDashedLine\(Vector2, Vector2, Color, float, float, bool, bool\), 
CanvasItem.DrawPolyline\(Vector2\[\], Color, float, bool\), 
CanvasItem.DrawPolyline\(ReadOnlySpan<Vector2\>, Color, float, bool\), 
CanvasItem.DrawPolylineColors\(Vector2\[\], Color\[\], float, bool\), 
CanvasItem.DrawPolylineColors\(ReadOnlySpan<Vector2\>, ReadOnlySpan<Color\>, float, bool\), 
CanvasItem.DrawArc\(Vector2, float, float, float, int, Color, float, bool\), 
CanvasItem.DrawMultiline\(Vector2\[\], Color, float, bool\), 
CanvasItem.DrawMultiline\(ReadOnlySpan<Vector2\>, Color, float, bool\), 
CanvasItem.DrawMultilineColors\(Vector2\[\], Color\[\], float, bool\), 
CanvasItem.DrawMultilineColors\(ReadOnlySpan<Vector2\>, ReadOnlySpan<Color\>, float, bool\), 
CanvasItem.DrawRect\(Rect2, Color, bool, float, bool\), 
CanvasItem.DrawCircle\(Vector2, float, Color, bool, float, bool\), 
CanvasItem.DrawTexture\(Texture2D, Vector2, Color?\), 
CanvasItem.DrawTextureRect\(Texture2D, Rect2, bool, Color?, bool\), 
CanvasItem.DrawTextureRectRegion\(Texture2D, Rect2, Rect2, Color?, bool, bool\), 
CanvasItem.DrawMsdfTextureRectRegion\(Texture2D, Rect2, Rect2, Color?, double, double, double\), 
CanvasItem.DrawLcdTextureRectRegion\(Texture2D, Rect2, Rect2, Color?\), 
CanvasItem.DrawStyleBox\(StyleBox, Rect2\), 
CanvasItem.DrawPrimitive\(Vector2\[\], Color\[\], Vector2\[\], Texture2D\), 
CanvasItem.DrawPrimitive\(ReadOnlySpan<Vector2\>, ReadOnlySpan<Color\>, ReadOnlySpan<Vector2\>, Texture2D\), 
CanvasItem.DrawPolygon\(Vector2\[\], Color\[\], Vector2\[\], Texture2D\), 
CanvasItem.DrawPolygon\(ReadOnlySpan<Vector2\>, ReadOnlySpan<Color\>, ReadOnlySpan<Vector2\>, Texture2D\), 
CanvasItem.DrawColoredPolygon\(Vector2\[\], Color, Vector2\[\], Texture2D\), 
CanvasItem.DrawColoredPolygon\(ReadOnlySpan<Vector2\>, Color, ReadOnlySpan<Vector2\>, Texture2D\), 
CanvasItem.DrawString\(Font, Vector2, string, HorizontalAlignment, float, int, Color?, TextServer.JustificationFlag, TextServer.Direction, TextServer.Orientation\), 
CanvasItem.DrawMultilineString\(Font, Vector2, string, HorizontalAlignment, float, int, int, Color?, TextServer.LineBreakFlag, TextServer.JustificationFlag, TextServer.Direction, TextServer.Orientation\), 
CanvasItem.DrawStringOutline\(Font, Vector2, string, HorizontalAlignment, float, int, int, Color?, TextServer.JustificationFlag, TextServer.Direction, TextServer.Orientation\), 
CanvasItem.DrawMultilineStringOutline\(Font, Vector2, string, HorizontalAlignment, float, int, int, int, Color?, TextServer.LineBreakFlag, TextServer.JustificationFlag, TextServer.Direction, TextServer.Orientation\), 
CanvasItem.DrawChar\(Font, Vector2, string, int, Color?\), 
CanvasItem.DrawCharOutline\(Font, Vector2, string, int, int, Color?\), 
CanvasItem.DrawMesh\(Mesh, Texture2D, Transform2D?, Color?\), 
CanvasItem.DrawMultimesh\(MultiMesh, Texture2D\), 
CanvasItem.DrawSetTransform\(Vector2, float, Vector2?\), 
CanvasItem.DrawSetTransformMatrix\(Transform2D\), 
CanvasItem.DrawAnimationSlice\(double, double, double, double\), 
CanvasItem.DrawEndAnimation\(\), 
CanvasItem.GetTransform\(\), 
CanvasItem.GetGlobalTransform\(\), 
CanvasItem.GetGlobalTransformWithCanvas\(\), 
CanvasItem.GetViewportTransform\(\), 
CanvasItem.GetViewportRect\(\), 
CanvasItem.GetCanvasTransform\(\), 
CanvasItem.GetScreenTransform\(\), 
CanvasItem.GetLocalMousePosition\(\), 
CanvasItem.GetGlobalMousePosition\(\), 
CanvasItem.GetCanvas\(\), 
CanvasItem.GetCanvasLayerNode\(\), 
CanvasItem.GetWorld2D\(\), 
CanvasItem.SetMaterial\(Material\), 
CanvasItem.GetMaterial\(\), 
CanvasItem.SetUseParentMaterial\(bool\), 
CanvasItem.GetUseParentMaterial\(\), 
CanvasItem.SetNotifyLocalTransform\(bool\), 
CanvasItem.IsLocalTransformNotificationEnabled\(\), 
CanvasItem.SetNotifyTransform\(bool\), 
CanvasItem.IsTransformNotificationEnabled\(\), 
CanvasItem.ForceUpdateTransform\(\), 
CanvasItem.MakeCanvasPositionLocal\(Vector2\), 
CanvasItem.MakeInputLocal\(InputEvent\), 
CanvasItem.SetVisibilityLayer\(uint\), 
CanvasItem.GetVisibilityLayer\(\), 
CanvasItem.SetVisibilityLayerBit\(uint, bool\), 
CanvasItem.GetVisibilityLayerBit\(uint\), 
CanvasItem.SetTextureFilter\(CanvasItem.TextureFilterEnum\), 
CanvasItem.GetTextureFilter\(\), 
CanvasItem.SetTextureRepeat\(CanvasItem.TextureRepeatEnum\), 
CanvasItem.GetTextureRepeat\(\), 
CanvasItem.SetClipChildrenMode\(CanvasItem.ClipChildrenMode\), 
CanvasItem.GetClipChildrenMode\(\), 
CanvasItem.DrawMultilineColors\(Vector2\[\], Color\[\], float\), 
CanvasItem.DrawMultilineColors\(ReadOnlySpan<Vector2\>, ReadOnlySpan<Color\>, float\), 
CanvasItem.DrawMultiline\(Vector2\[\], Color, float\), 
CanvasItem.DrawMultiline\(ReadOnlySpan<Vector2\>, Color, float\), 
CanvasItem.DrawDashedLine\(Vector2, Vector2, Color, float, float, bool\), 
CanvasItem.DrawRect\(Rect2, Color, bool, float\), 
CanvasItem.DrawCircle\(Vector2, float, Color\), 
CanvasItem.EmitSignalDraw\(\), 
CanvasItem.EmitSignalVisibilityChanged\(\), 
CanvasItem.EmitSignalHidden\(\), 
CanvasItem.EmitSignalItemRectChanged\(\), 
CanvasItem.InvokeGodotClassMethod\(in godot\_string\_name, NativeVariantPtrArgs, out godot\_variant\), 
CanvasItem.HasGodotClassMethod\(in godot\_string\_name\), 
CanvasItem.HasGodotClassSignal\(in godot\_string\_name\), 
CanvasItem.Visible, 
CanvasItem.Modulate, 
CanvasItem.SelfModulate, 
CanvasItem.ShowBehindParent, 
CanvasItem.TopLevel, 
CanvasItem.ClipChildren, 
CanvasItem.LightMask, 
CanvasItem.VisibilityLayer, 
CanvasItem.ZIndex, 
CanvasItem.ZAsRelative, 
CanvasItem.YSortEnabled, 
CanvasItem.TextureFilter, 
CanvasItem.TextureRepeat, 
CanvasItem.Material, 
CanvasItem.UseParentMaterial, 
CanvasItem.Draw, 
CanvasItem.VisibilityChanged, 
CanvasItem.Hidden, 
CanvasItem.ItemRectChanged, 
Node.NotificationEnterTree, 
Node.NotificationExitTree, 
Node.NotificationMovedInParent, 
Node.NotificationReady, 
Node.NotificationPaused, 
Node.NotificationUnpaused, 
Node.NotificationPhysicsProcess, 
Node.NotificationProcess, 
Node.NotificationParented, 
Node.NotificationUnparented, 
Node.NotificationSceneInstantiated, 
Node.NotificationDragBegin, 
Node.NotificationDragEnd, 
Node.NotificationPathRenamed, 
Node.NotificationChildOrderChanged, 
Node.NotificationInternalProcess, 
Node.NotificationInternalPhysicsProcess, 
Node.NotificationPostEnterTree, 
Node.NotificationDisabled, 
Node.NotificationEnabled, 
Node.NotificationResetPhysicsInterpolation, 
Node.NotificationEditorPreSave, 
Node.NotificationEditorPostSave, 
Node.NotificationWMMouseEnter, 
Node.NotificationWMMouseExit, 
Node.NotificationWMWindowFocusIn, 
Node.NotificationWMWindowFocusOut, 
Node.NotificationWMCloseRequest, 
Node.NotificationWMGoBackRequest, 
Node.NotificationWMSizeChanged, 
Node.NotificationWMDpiChange, 
Node.NotificationVpMouseEnter, 
Node.NotificationVpMouseExit, 
Node.NotificationOsMemoryWarning, 
Node.NotificationTranslationChanged, 
Node.NotificationWMAbout, 
Node.NotificationCrash, 
Node.NotificationOsImeUpdate, 
Node.NotificationApplicationResumed, 
Node.NotificationApplicationPaused, 
Node.NotificationApplicationFocusIn, 
Node.NotificationApplicationFocusOut, 
Node.NotificationTextServerChanged, 
Node.GetNode<T\>\(NodePath\), 
Node.GetNodeOrNull<T\>\(NodePath\), 
Node.GetChild<T\>\(int, bool\), 
Node.GetChildOrNull<T\>\(int, bool\), 
Node.GetOwner<T\>\(\), 
Node.GetOwnerOrNull<T\>\(\), 
Node.GetParent<T\>\(\), 
Node.GetParentOrNull<T\>\(\), 
Node.\_EnterTree\(\), 
Node.\_ExitTree\(\), 
Node.\_GetConfigurationWarnings\(\), 
Node.\_Input\(InputEvent\), 
Node.\_PhysicsProcess\(double\), 
Node.\_Process\(double\), 
Node.\_Ready\(\), 
Node.\_ShortcutInput\(InputEvent\), 
Node.\_UnhandledInput\(InputEvent\), 
Node.\_UnhandledKeyInput\(InputEvent\), 
Node.PrintOrphanNodes\(\), 
Node.AddSibling\(Node, bool\), 
Node.SetName\(string\), 
Node.GetName\(\), 
Node.AddChild\(Node, bool, Node.InternalMode\), 
Node.RemoveChild\(Node\), 
Node.Reparent\(Node, bool\), 
Node.GetChildCount\(bool\), 
Node.GetChildren\(bool\), 
Node.GetChild\(int, bool\), 
Node.HasNode\(NodePath\), 
Node.GetNode\(NodePath\), 
Node.GetNodeOrNull\(NodePath\), 
Node.GetParent\(\), 
Node.FindChild\(string, bool, bool\), 
Node.FindChildren\(string, string, bool, bool\), 
Node.FindParent\(string\), 
Node.HasNodeAndResource\(NodePath\), 
Node.GetNodeAndResource\(NodePath\), 
Node.IsInsideTree\(\), 
Node.IsPartOfEditedScene\(\), 
Node.IsAncestorOf\(Node\), 
Node.IsGreaterThan\(Node\), 
Node.GetPath\(\), 
Node.GetPathTo\(Node, bool\), 
Node.AddToGroup\(StringName, bool\), 
Node.RemoveFromGroup\(StringName\), 
Node.IsInGroup\(StringName\), 
Node.MoveChild\(Node, int\), 
Node.GetGroups\(\), 
Node.SetOwner\(Node\), 
Node.GetOwner\(\), 
Node.GetIndex\(bool\), 
Node.PrintTree\(\), 
Node.PrintTreePretty\(\), 
Node.GetTreeString\(\), 
Node.GetTreeStringPretty\(\), 
Node.SetSceneFilePath\(string\), 
Node.GetSceneFilePath\(\), 
Node.PropagateNotification\(int\), 
Node.PropagateCall\(StringName, Array, bool\), 
Node.SetPhysicsProcess\(bool\), 
Node.GetPhysicsProcessDeltaTime\(\), 
Node.IsPhysicsProcessing\(\), 
Node.GetProcessDeltaTime\(\), 
Node.SetProcess\(bool\), 
Node.SetProcessPriority\(int\), 
Node.GetProcessPriority\(\), 
Node.SetPhysicsProcessPriority\(int\), 
Node.GetPhysicsProcessPriority\(\), 
Node.IsProcessing\(\), 
Node.SetProcessInput\(bool\), 
Node.IsProcessingInput\(\), 
Node.SetProcessShortcutInput\(bool\), 
Node.IsProcessingShortcutInput\(\), 
Node.SetProcessUnhandledInput\(bool\), 
Node.IsProcessingUnhandledInput\(\), 
Node.SetProcessUnhandledKeyInput\(bool\), 
Node.IsProcessingUnhandledKeyInput\(\), 
Node.SetProcessMode\(Node.ProcessModeEnum\), 
Node.GetProcessMode\(\), 
Node.CanProcess\(\), 
Node.SetProcessThreadGroup\(Node.ProcessThreadGroupEnum\), 
Node.GetProcessThreadGroup\(\), 
Node.SetProcessThreadMessages\(Node.ProcessThreadMessagesEnum\), 
Node.GetProcessThreadMessages\(\), 
Node.SetProcessThreadGroupOrder\(int\), 
Node.GetProcessThreadGroupOrder\(\), 
Node.SetDisplayFolded\(bool\), 
Node.IsDisplayedFolded\(\), 
Node.SetProcessInternal\(bool\), 
Node.IsProcessingInternal\(\), 
Node.SetPhysicsProcessInternal\(bool\), 
Node.IsPhysicsProcessingInternal\(\), 
Node.SetPhysicsInterpolationMode\(Node.PhysicsInterpolationModeEnum\), 
Node.GetPhysicsInterpolationMode\(\), 
Node.IsPhysicsInterpolated\(\), 
Node.IsPhysicsInterpolatedAndEnabled\(\), 
Node.ResetPhysicsInterpolation\(\), 
Node.SetAutoTranslateMode\(Node.AutoTranslateModeEnum\), 
Node.GetAutoTranslateMode\(\), 
Node.SetTranslationDomainInherited\(\), 
Node.GetWindow\(\), 
Node.GetLastExclusiveWindow\(\), 
Node.GetTree\(\), 
Node.CreateTween\(\), 
Node.Duplicate\(int\), 
Node.ReplaceBy\(Node, bool\), 
Node.SetSceneInstanceLoadPlaceholder\(bool\), 
Node.GetSceneInstanceLoadPlaceholder\(\), 
Node.SetEditableInstance\(Node, bool\), 
Node.IsEditableInstance\(Node\), 
Node.GetViewport\(\), 
Node.QueueFree\(\), 
Node.RequestReady\(\), 
Node.IsNodeReady\(\), 
Node.SetMultiplayerAuthority\(int, bool\), 
Node.GetMultiplayerAuthority\(\), 
Node.IsMultiplayerAuthority\(\), 
Node.GetMultiplayer\(\), 
Node.RpcConfig\(StringName, Variant\), 
Node.GetRpcConfig\(\), 
Node.SetEditorDescription\(string\), 
Node.GetEditorDescription\(\), 
Node.SetUniqueNameInOwner\(bool\), 
Node.IsUniqueNameInOwner\(\), 
Node.Atr\(string, StringName\), 
Node.AtrN\(string, StringName, int, StringName\), 
Node.Rpc\(StringName, params Variant\[\]\), 
Node.Rpc\(StringName, ReadOnlySpan<Variant\>\), 
Node.RpcId\(long, StringName, params Variant\[\]\), 
Node.RpcId\(long, StringName, ReadOnlySpan<Variant\>\), 
Node.UpdateConfigurationWarnings\(\), 
Node.CallDeferredThreadGroup\(StringName, params Variant\[\]\), 
Node.CallDeferredThreadGroup\(StringName, ReadOnlySpan<Variant\>\), 
Node.SetDeferredThreadGroup\(StringName, Variant\), 
Node.NotifyDeferredThreadGroup\(int\), 
Node.CallThreadSafe\(StringName, params Variant\[\]\), 
Node.CallThreadSafe\(StringName, ReadOnlySpan<Variant\>\), 
Node.SetThreadSafe\(StringName, Variant\), 
Node.NotifyThreadSafe\(int\), 
Node.EmitSignalReady\(\), 
Node.EmitSignalRenamed\(\), 
Node.EmitSignalTreeEntered\(\), 
Node.EmitSignalTreeExiting\(\), 
Node.EmitSignalTreeExited\(\), 
Node.EmitSignalChildEnteredTree\(Node\), 
Node.EmitSignalChildExitingTree\(Node\), 
Node.EmitSignalChildOrderChanged\(\), 
Node.EmitSignalReplacingBy\(Node\), 
Node.EmitSignalEditorDescriptionChanged\(Node\), 
Node.EmitSignalEditorStateChanged\(\), 
Node.InvokeGodotClassMethod\(in godot\_string\_name, NativeVariantPtrArgs, out godot\_variant\), 
Node.HasGodotClassMethod\(in godot\_string\_name\), 
Node.HasGodotClassSignal\(in godot\_string\_name\), 
Node.\_ImportPath, 
Node.Name, 
Node.UniqueNameInOwner, 
Node.SceneFilePath, 
Node.Owner, 
Node.Multiplayer, 
Node.ProcessMode, 
Node.ProcessPriority, 
Node.ProcessPhysicsPriority, 
Node.ProcessThreadGroup, 
Node.ProcessThreadGroupOrder, 
Node.ProcessThreadMessages, 
Node.PhysicsInterpolationMode, 
Node.AutoTranslateMode, 
Node.EditorDescription, 
Node.Ready, 
Node.Renamed, 
Node.TreeEntered, 
Node.TreeExiting, 
Node.TreeExited, 
Node.ChildEnteredTree, 
Node.ChildExitingTree, 
Node.ChildOrderChanged, 
Node.ReplacingBy, 
Node.EditorDescriptionChanged, 
Node.EditorStateChanged, 
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

### <a id="DiceRoll_Helpers_Arc2D__arcMidpoint"></a> \_arcMidpoint

```csharp
private Vector2 _arcMidpoint
```

#### Field Value

 Vector2

### <a id="DiceRoll_Helpers_Arc2D__bendDirection"></a> \_bendDirection

```csharp
private string _bendDirection
```

#### Field Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)

### <a id="DiceRoll_Helpers_Arc2D__bendStrength"></a> \_bendStrength

```csharp
private int _bendStrength
```

#### Field Value

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRoll_Helpers_Arc2D__end"></a> \_end

```csharp
private Vector2 _end
```

#### Field Value

 Vector2

### <a id="DiceRoll_Helpers_Arc2D__lastEndPosition"></a> \_lastEndPosition

```csharp
private Vector2 _lastEndPosition
```

#### Field Value

 Vector2

### <a id="DiceRoll_Helpers_Arc2D__lastStartPosition"></a> \_lastStartPosition

```csharp
private Vector2 _lastStartPosition
```

#### Field Value

 Vector2

### <a id="DiceRoll_Helpers_Arc2D__midpoint"></a> \_midpoint

```csharp
private Vector2 _midpoint
```

#### Field Value

 Vector2

### <a id="DiceRoll_Helpers_Arc2D__smoothness"></a> \_smoothness

```csharp
private int _smoothness
```

#### Field Value

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRoll_Helpers_Arc2D__start"></a> \_start

```csharp
private Vector2 _start
```

#### Field Value

 Vector2

## Properties

### <a id="DiceRoll_Helpers_Arc2D_BendDirection"></a> BendDirection

```csharp
[Export(PropertyHint.None, "")]
public string BendDirection { get; set; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)

### <a id="DiceRoll_Helpers_Arc2D_BendStrength"></a> BendStrength

```csharp
[Export(PropertyHint.None, "")]
public int BendStrength { get; set; }
```

#### Property Value

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRoll_Helpers_Arc2D_Smoothness"></a> Smoothness

```csharp
[Export(PropertyHint.None, "")]
public int Smoothness { get; set; }
```

#### Property Value

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

## Methods

### <a id="DiceRoll_Helpers_Arc2D_GetBendDirection"></a> GetBendDirection\(\)

```csharp
private Vector2 GetBendDirection()
```

#### Returns

 Vector2

### <a id="DiceRoll_Helpers_Arc2D_GetGodotClassPropertyValue_Godot_NativeInterop_godot_string_name__Godot_NativeInterop_godot_variant__"></a> GetGodotClassPropertyValue\(in godot\_string\_name, out godot\_variant\)

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

### <a id="DiceRoll_Helpers_Arc2D_GetGodotMethodList"></a> GetGodotMethodList\(\)

Get the method information for all the methods declared in this class.
This method is used by Godot to register the available methods in the editor.
Do not call this method.

```csharp
[EditorBrowsable(EditorBrowsableState.Never)]
internal static List<MethodInfo> GetGodotMethodList()
```

#### Returns

 [List](https://learn.microsoft.com/dotnet/api/system.collections.generic.list\-1)<MethodInfo\>

### <a id="DiceRoll_Helpers_Arc2D_GetGodotPropertyList"></a> GetGodotPropertyList\(\)

Get the property information for all the properties declared in this class.
This method is used by Godot to register the available properties in the editor.
Do not call this method.

```csharp
[EditorBrowsable(EditorBrowsableState.Never)]
internal static List<PropertyInfo> GetGodotPropertyList()
```

#### Returns

 [List](https://learn.microsoft.com/dotnet/api/system.collections.generic.list\-1)<PropertyInfo\>

### <a id="DiceRoll_Helpers_Arc2D_HasGodotClassMethod_Godot_NativeInterop_godot_string_name__"></a> HasGodotClassMethod\(in godot\_string\_name\)

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

### <a id="DiceRoll_Helpers_Arc2D_InterpolateArcPoint_System_Single_"></a> InterpolateArcPoint\(float\)

```csharp
private Vector2 InterpolateArcPoint(float segment)
```

#### Parameters

`segment` [float](https://learn.microsoft.com/dotnet/api/system.single)

#### Returns

 Vector2

### <a id="DiceRoll_Helpers_Arc2D_InvokeGodotClassMethod_Godot_NativeInterop_godot_string_name__Godot_NativeInterop_NativeVariantPtrArgs_Godot_NativeInterop_godot_variant__"></a> InvokeGodotClassMethod\(in godot\_string\_name, NativeVariantPtrArgs, out godot\_variant\)

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

### <a id="DiceRoll_Helpers_Arc2D_IsPositionTheSame"></a> IsPositionTheSame\(\)

```csharp
private bool IsPositionTheSame()
```

#### Returns

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

### <a id="DiceRoll_Helpers_Arc2D_ResetPoints"></a> ResetPoints\(\)

```csharp
private void ResetPoints()
```

### <a id="DiceRoll_Helpers_Arc2D_RestoreGodotObjectData_Godot_Bridge_GodotSerializationInfo_"></a> RestoreGodotObjectData\(GodotSerializationInfo\)

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

### <a id="DiceRoll_Helpers_Arc2D_SaveGodotObjectData_Godot_Bridge_GodotSerializationInfo_"></a> SaveGodotObjectData\(GodotSerializationInfo\)

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

### <a id="DiceRoll_Helpers_Arc2D_SetArcSegments"></a> SetArcSegments\(\)

```csharp
private void SetArcSegments()
```

### <a id="DiceRoll_Helpers_Arc2D_SetExtremePoints"></a> SetExtremePoints\(\)

```csharp
private void SetExtremePoints()
```

### <a id="DiceRoll_Helpers_Arc2D_SetGodotClassPropertyValue_Godot_NativeInterop_godot_string_name__Godot_NativeInterop_godot_variant__"></a> SetGodotClassPropertyValue\(in godot\_string\_name, in godot\_variant\)

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

### <a id="DiceRoll_Helpers_Arc2D_SetMidpoints"></a> SetMidpoints\(\)

```csharp
private void SetMidpoints()
```

### <a id="DiceRoll_Helpers_Arc2D_SetupArcFlexible"></a> SetupArcFlexible\(\)

```csharp
private void SetupArcFlexible()
```

### <a id="DiceRoll_Helpers_Arc2D_SetupArcStatic"></a> SetupArcStatic\(\)

```csharp
private void SetupArcStatic()
```

### <a id="DiceRoll_Helpers_Arc2D__Process_System_Double_"></a> \_Process\(double\)

<p>Called during the processing step of the main loop. Processing happens at every frame and as fast as possible, so the <code class="paramref">delta</code> time since the previous frame is not constant. <code class="paramref">delta</code> is in seconds.</p>
<p>It is only called if processing is enabled, which is done automatically if this method is overridden, and can be toggled with <xref href="Godot.Node.SetProcess(System.Boolean)" data-throw-if-not-resolved="false"></xref>.</p>
<p>Processing happens in order of <xref href="Godot.Node.ProcessPriority" data-throw-if-not-resolved="false"></xref>, lower priority values are called first. Nodes with the same priority are processed in tree order, or top to bottom as seen in the editor (also known as pre-order traversal).</p>
<p>Corresponds to the <xref href="Godot.Node.NotificationProcess" data-throw-if-not-resolved="false"></xref> notification in <xref href="Godot.GodotObject._Notification(System.Int32)" data-throw-if-not-resolved="false"></xref>.</p>
<p>
  <b>Note:</b> This method is only called if the node is present in the scene tree (i.e. if it's not an orphan).</p>
<p>
  <b>Note:</b>
  <code class="paramref">delta</code> will be larger than expected if running at a framerate lower than <xref href="Godot.Engine.PhysicsTicksPerSecond" data-throw-if-not-resolved="false"></xref> / <xref href="Godot.Engine.MaxPhysicsStepsPerFrame" data-throw-if-not-resolved="false"></xref> FPS. This is done to avoid "spiral of death" scenarios where performance would plummet due to an ever-increasing number of physics steps per frame. This behavior affects both <xref href="Godot.Node._Process(System.Double)" data-throw-if-not-resolved="false"></xref> and <xref href="Godot.Node._PhysicsProcess(System.Double)" data-throw-if-not-resolved="false"></xref>. As a result, avoid using <code class="paramref">delta</code> for time measurements in real-world seconds. Use the <xref href="Godot.Time" data-throw-if-not-resolved="false"></xref> singleton's methods for this purpose instead, such as <xref href="Godot.Time.GetTicksUsec" data-throw-if-not-resolved="false"></xref>.</p>

```csharp
public override void _Process(double delta)
```

#### Parameters

`delta` [double](https://learn.microsoft.com/dotnet/api/system.double)

