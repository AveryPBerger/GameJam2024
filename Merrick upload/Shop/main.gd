extends Node3D

@onready var camera = $Camera3D
@onready var anim = $AnimationPlayer

var window = true

signal lookAtLab
signal lookAtWindow

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	if Input.is_action_just_released("ui_left") or Input.is_action_just_released("ui_right"):
		#camera.rotate_y(PI)
		if window == true:
			window = false
			lookAtLab.emit()
			
		else:
			window = true
			lookAtWindow.emit()
			
		print(window)
