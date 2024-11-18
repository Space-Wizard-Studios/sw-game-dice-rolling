@tool
extends RefCounted

# CLASS GOT AUTOGENERATED DON'T CHANGE MANUALLY. CHANGES CAN BE OVERWRITTEN EASILY.

class_name TwitchCreateChannelStreamScheduleSegmentBody

## The date and time that the broadcast segment starts. Specify the date and time in RFC3339 format (for example, 2021-07-01T18:00:00Z).
var start_time: Variant:
	set(val):
		start_time = val;
		changed_data["start_time"] = start_time;
## The time zone where the broadcast takes place. Specify the time zone using [IANA time zone database](https://www.iana.org/time-zones) format (for example, America/New\_York).
var timezone: String:
	set(val):
		timezone = val;
		changed_data["timezone"] = timezone;
## The length of time, in minutes, that the broadcast is scheduled to run. The duration must be in the range 30 through 1380 (23 hours).
var duration: String:
	set(val):
		duration = val;
		changed_data["duration"] = duration;
## A Boolean value that determines whether the broadcast recurs weekly. Is **true** if the broadcast recurs weekly. Only partners and affiliates may add non-recurring broadcasts.
var is_recurring: bool:
	set(val):
		is_recurring = val;
		changed_data["is_recurring"] = is_recurring;
## The ID of the category that best represents the broadcast’s content. To get the category ID, use the [Search Categories](https://dev.twitch.tv/docs/api/reference#search-categories) endpoint.
var category_id: String:
	set(val):
		category_id = val;
		changed_data["category_id"] = category_id;
## The broadcast’s title. The title may contain a maximum of 140 characters.
var title: String:
	set(val):
		title = val;
		changed_data["title"] = title;

var changed_data: Dictionary = {};

static func from_json(d: Dictionary) -> TwitchCreateChannelStreamScheduleSegmentBody:
	var result = TwitchCreateChannelStreamScheduleSegmentBody.new();
	if d.has("start_time") && d["start_time"] != null:
		result.start_time = d["start_time"];
	if d.has("timezone") && d["timezone"] != null:
		result.timezone = d["timezone"];
	if d.has("duration") && d["duration"] != null:
		result.duration = d["duration"];
	if d.has("is_recurring") && d["is_recurring"] != null:
		result.is_recurring = d["is_recurring"];
	if d.has("category_id") && d["category_id"] != null:
		result.category_id = d["category_id"];
	if d.has("title") && d["title"] != null:
		result.title = d["title"];
	return result;

func to_dict() -> Dictionary:
	return changed_data;

func to_json() -> String:
	return JSON.stringify(to_dict());

