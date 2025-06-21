using Godot;
using System;

public partial class GlobalHUD : Control
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
	private Label _coinCounterLabel;
	private Control _UIFinal;
	private ColorRect _blackVeil;
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
			_coinCounterLabel = GetNode<Label>("CoinCounterLabel");
			_UIFinal = GetNode<Control>("UIFInal");
			_blackVeil = GetNode<ColorRect>("UIFInal/BlackVeil");

			// Signal connections
			// Engine (automatically freed)

			// Customs (need to be freed manually)
			// Local and external emitter (freed in _ExitTree())
			_gameEvents.CoinCounterChanged += OnCoinCounterChanged;
			_gameEvents.YouWin += OnYouWin;
			// Children emitter (automatically freed))

			// Logic
		}
		catch (Exception e)
		{
			GD.PushError($"Error while loading GlobalHUD : ", e);
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
			_gameEvents.CoinCounterChanged -= OnCoinCounterChanged;
			_gameEvents.YouWin -= OnYouWin;
		}
		catch (Exception e)
		{
			GD.PushError($"Error while unloading GlobalHUD : ", e);
		}
	}

	// Called every frame synced to the physics. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{

	}

	#endregion

	#region ON_SIGNALS
	private void OnCoinCounterChanged(int count)
	{
		_coinCounterLabel.Text = count.ToString();
	}
	private void OnYouWin()
	{
		_UIFinal.Visible = true;
		Tween fadeTween = CreateTween();
		fadeTween.TweenProperty(_blackVeil, "color:a", 0.5, 0.2);
		fadeTween.TweenCallback(Callable.From(() => GetTree().Paused = true));//.SetDelay(2.0f);
	}
	#endregion

	#region LOGIC

	#endregion

	#endregion
}

