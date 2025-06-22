	using Godot;
using System;

public partial class Menu : Control
{
	#region CONSTANTS
	#endregion

	#region PROPERTIES

	#region EXPORTS
	#endregion

	#region FIELDS
	#endregion

	#region SIGNALS
	#endregion

	#region ONREADY
	private Button _playButton;
	private Button _jamInfoButton;
	#endregion

	#endregion

	#region METHODS

	#region ENGINE

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		try
		{
			// On ready
			_playButton = GetNode<Button>("PlayButton");
			_jamInfoButton = GetNode<Button>("JamInfoButton");
			// Signal connections
			// Engine (automatically freed)

			// Customs (need to be freed manually)
			// Local and external emitter (freed in _ExitTree())

			// Children emitter (automatically freed))
			_playButton.Pressed += OnPlayButtonPressed;
			_jamInfoButton.Pressed += OnJamInfoButtonPressed;

			// Logic
		}
		catch (Exception e)
		{
			GD.PushError($"Error while loading Menu : ", e);
		}
	}

	// Called when the node is about to leave the Godot.SceneTree
	public override void _ExitTree()
	{
		try
		{
			// Call parent _ExitTree()
			base._ExitTree();
			// Custom local and external signals freeing

		}
		catch (Exception e)
		{
			GD.PushError($"Error while unloading Menu : ", e);
		}
	}

	// Called every frame synced to the physics. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{

	}

	#endregion

	#region ON_SIGNALS
	private void OnPlayButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/Level/level1.tscn");
	}
	private void OnJamInfoButtonPressed()
	{

	}
	#endregion

	#region LOGIC

	#endregion

	#endregion
}

