@tool
extends EditorPlugin


var editor_button_plugin:EditorButtonPlugin


func _enter_tree() -> void:
	editor_button_plugin = EditorButtonPlugin.new()
	add_inspector_plugin(editor_button_plugin)


func _exit_tree() -> void:
	if is_instance_valid(editor_button_plugin):
		remove_inspector_plugin(editor_button_plugin)
		editor_button_plugin = null


class EditorButtonPlugin extends EditorInspectorPlugin:


	func _can_handle(object: Object) -> bool:
		return object.has_method('_add_inspector_buttons')


	func _parse_begin(object: Object) -> void:
		var buttons_data = object._add_inspector_buttons()
		for button_data in buttons_data:
			var name = button_data.get("name", null)
			var icon = button_data.get("icon", null)
			var pressed = button_data.get("pressed", null)
			if not name:
				push_warning('_add_inspector_buttons(): A button does not have a name key. Defaulting to: "Button"')
				name = "Button"
			if icon and not icon is Texture:
				push_warning('_add_inspector_buttons(): The button <{name}> icon is not a texture.'.format({"name":name}))
				icon = null
			if not pressed:
				push_warning('_add_inspector_buttons(): The button <{name}> does not have a pressed key. Skipping.'.format({"name":name}))
				continue
			if not pressed is Callable:
				push_warning('_add_inspector_buttons(): The button <{name}> pressed is not a Callable. Skipping.'.format({"name":name}))
				continue

			var button = Button.new()
			button.text = name
			if icon:
				button.icon = icon
				button.expand_icon = true
			button.pressed.connect(pressed)
			add_custom_control(button)