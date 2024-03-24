extends Control

@onready var label = $layer1/TextureRect/RichTextLabel
@onready var textbox = $layer1
@onready var anim = $AnimationPlayer
@onready var children = self.get_children()

# Called when the node enters the scene tree for the first time.
func _ready():
	anim.current_animation = "shake"


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass


func _on_node_3d_look_at_lab():
	textbox.hide()


func _on_node_3d_look_at_window():
	textbox.show()

