@tool
extends RefCounted

# CLASS GOT AUTOGENERATED DON'T CHANGE MANUALLY. CHANGES CAN BE OVERWRITTEN EASILY.

class_name TwitchGetExtensionConfigurationSegmentResponse

## The list of requested configuration segments. The list is returned in the same order that you specified the list of segments in the request.
var data: Array[TwitchExtensionConfigurationSegment]:
	set(val):
		data = val;
		changed_data["data"] = [];
		if data != null:
			for value in data:
				changed_data["data"].append(value.to_dict());

var changed_data: Dictionary = {};

static func from_json(d: Dictionary) -> TwitchGetExtensionConfigurationSegmentResponse:
	var result = TwitchGetExtensionConfigurationSegmentResponse.new();
	if d.has("data") && d["data"] != null:
		for value in d["data"]:
			result.data.append(TwitchExtensionConfigurationSegment.from_json(value));
	return result;

func to_dict() -> Dictionary:
	return changed_data;

func to_json() -> String:
	return JSON.stringify(to_dict());

