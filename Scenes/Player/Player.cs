using Godot;
using System;

public partial class Player : CharacterBody2D
{
	#region CONSTANTS
	#endregion

	#region PROPERTIES

	#region EXPORTS
	#endregion

	#region FIELD
	#endregion

	#region SIGNALS
	#endregion

	#region ONREADY

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

			// Signal connections
			// Engine (automatically freed)

			// Customs (need to be freed manually)
			// Local and external emitter (freed in _ExitTree())

			// Children emitter (automatically freed))

			// Logic
		}
		catch (Exception e)
		{
			GD.PushError($"Error while loading Player : ", e);
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
			GD.PushError($"Error while unloading Player : ", e);
		}
	}

	// Called every frame synced to the physics. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{

	}

	public override void _Input(InputEvent @event)
	{
		Vector2 TargetPosition = Vector2.Inf;
		if (@event.IsActionPressed("up"))
			TargetPosition = new Vector2(Position.X, Position.Y - 500);
		else if (@event.IsActionPressed("right"))
			TargetPosition = new Vector2(Position.X + 500, Position.Y);
		else if (@event.IsActionPressed("down"))
			TargetPosition = new Vector2(Position.X, Position.Y + 500);
		else if (@event.IsActionPressed("left"))
			TargetPosition = new Vector2(Position.X - 500, Position.Y);

		if (TargetPosition != Vector2.Inf)
		{
			Vector2 direction = Position.DirectionTo(TargetPosition);
			float distance = Position.DistanceTo(TargetPosition);
			MoveAndCollide(direction * distance);
		}
	}

	#endregion

	#region ON_SIGNALS

	#endregion

	#region LOGIC

	#endregion

	#endregion
}

