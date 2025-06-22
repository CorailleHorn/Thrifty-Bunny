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
			_gameEvents = GetNode<GameEvents>("/root/GameEvents");
			_animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

			// Signal connections
			// Engine (automatically freed)

			// Customs (need to be freed manually)
			// Local and external emitter (freed in _ExitTree())
			_gameEvents.OpenChest += OnOpenChest;
			// Children emitter (automatically freed))
			_animatedSprite2D.AnimationFinished += OnAnimatedSprite2DAnimationFinished;

			// Logic
			_animatedSprite2D.Play("idle");
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
			_gameEvents.OpenChest -= OnOpenChest;

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
	private void OnAnimatedSprite2DAnimationFinished()
	{
		if (_animatedSprite2D.Animation == "open")
		{
			_gameEvents.EmitSignal(GameEvents.SignalName.YouWin);
		}
	}
	private void OnOpenChest()
	{
		_animatedSprite2D.Play("open");
	}


	#endregion

	#region LOGIC

	#endregion

	#endregion
}

