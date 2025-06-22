using Godot;
using System;

public partial class GlobalAudioStreamPlayer : AudioStreamPlayer
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
	private AudioStreamPlayer _coinAudioStreamPlayer;
	private AudioStreamPlayer _clicAudioStreamPlayer;
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
			_coinAudioStreamPlayer = GetNode<AudioStreamPlayer>("CoinAudioStreamPlayer");
			_clicAudioStreamPlayer = GetNode<AudioStreamPlayer>("ClicAudioStreamPlayer");
			// Signal connections
			// Engine (automatically freed)

			// Customs (need to be freed manually)
			// Local and external emitter (freed in _ExitTree())
			_gameEvents.PlayCoinSound += OnPlayCoinSound;
			_gameEvents.PlayClicSound += OnPlayClicSound;
			// Children emitter (automatically freed))

			// Logic
			Play();
		}
		catch (Exception e)
		{
			GD.PushError($"Error while loading GlobalAudioStreamPlayer : ", e);
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
			_gameEvents.PlayCoinSound -= OnPlayCoinSound;
			_gameEvents.PlayClicSound -= OnPlayClicSound;
		}
		catch (Exception e)
		{
			GD.PushError($"Error while unloading GlobalAudioStreamPlayer : ", e);
		}
	}

	// Called every frame synced to the physics. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{

	}

	#endregion

	#region ON_SIGNALS
	private void OnPlayCoinSound() => _coinAudioStreamPlayer.Play();
	private void OnPlayClicSound() => _clicAudioStreamPlayer.Play();
	#endregion

	#region LOGIC

	#endregion

	#endregion
}

