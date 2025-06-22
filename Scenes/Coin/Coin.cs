using Godot;
using System;

public partial class Coin : Node2D
{
	#region CONSTANTS
	#endregion

	#region PROPERTIES

	#region EXPORTS
	[Export]
	public int Value = 1;
	#endregion

	#region FIELDS
	#endregion

	#region SIGNALS
	#endregion

	#region ONREADY
	private Area2D _area2D;
	private AnimatedSprite2D _animatedSprite2D;
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
			_area2D = GetNode<Area2D>("Area2D");
			_animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
			// Signal connections
			// Engine (automatically freed)

			// Customs (need to be freed manually)
			// Local and external emitter (freed in _ExitTree())

			// Children emitter (automatically freed))
			_area2D.BodyEntered += OnArea2DBodyEntered;
			// Logic
			_animatedSprite2D.Play("idle");
		}
		catch (Exception e)
		{
			GD.PushError($"Error while loading Coin : ", e);
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
			GD.PushError($"Error while unloading Coin : ", e);
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
			//_area2D.Monitoring = false;
			player.Coin += Value;
			QueueFree();
		}
	}
	#endregion

	#region LOGIC

	#endregion

	#endregion
}

