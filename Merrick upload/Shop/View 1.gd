extends Node3D

var switch = false
# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	if Input.is_action_just_released("ui_left") or Input.is_action_just_released("ui_right"):
		if switch == true:
			position.x = -0.007
			switch = false
		else:
			position.x = -2
			switch = true
