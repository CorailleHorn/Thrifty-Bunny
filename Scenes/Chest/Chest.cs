using Godot;
using System;

public partial class Chest : Node2D
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
	private GameEvents _gameEvents;

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
			_gameEvents = GetNode<GameEvents>("/root/GameEvents");

			// Signal connections
			// Engine (automatically freed)

			// Customs (need to be freed manually)
			// Local and external emitter (freed in _ExitTree())

			// Children emitter (automatically freed))
			//_area2D.BodyEntered += OnArea2DBodyEntered;
			// Logic
		}
		catch (Exception e)
		{
			GD.PushError($"Error while loading Chest : ", e);
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
			GD.PushError($"Error while unloading Chest : ", e);
		}
	}

	// Called every frame synced to the physics. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{

	}

	#endregion

	#region ON_SIGNALS
	private void OnArea2DBodyEntered(Node2D body)
	{
		if (body is Player player)
		{
			_gameEvents.EmitSignal(GameEvents.SignalName.YouWin);
		}
	}

	#endregion

	#region LOGIC

	#endregion

	#endregion
}

