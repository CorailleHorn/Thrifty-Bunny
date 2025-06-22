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
	private Control _UIYouWin;
	private Control _UIYouLoose;
	private ColorRect _blackVeil;
	private Button _nextLevelButton;
	private Button _retryButton;
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
			_UIYouWin = GetNode<Control>("UIYouWin");
			_UIYouLoose = GetNode<Control>("UIYouLoose");
			_blackVeil = GetNode<ColorRect>("BlackVeil");
			_nextLevelButton = GetNode<Button>("UIYouWin/NextLevelButton");
			_retryButton = GetNode<Button>("UIYouLoose/RetryButton");

			// Signal connections
			// Engine (automatically freed)

			// Customs (need to be freed manually)
			// Local and external emitter (freed in _ExitTree())
			_gameEvents.CoinCounterChanged += OnCoinCounterChanged;
			_gameEvents.YouWin += OnYouWin;
			_gameEvents.YouLoose += OnYouLoose;
			// Children emitter (automatically freed))
			_nextLevelButton.Pressed += OnNextLevelButtonPressed;
			_retryButton.Pressed += OnRetryButtonPressed;
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
			_gameEvents.YouLoose -= OnYouLoose;
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
		_UIYouWin.Visible = true;
		ShowBlackVeil();
	}

	private void OnYouLoose()
	{
		_UIYouLoose.Visible = true;
		ShowBlackVeil();
	}
	private void OnNextLevelButtonPressed()
	{

	}

	private void OnRetryButtonPressed()
	{
		GetTree().ReloadCurrentScene();
	}
	#endregion

	#region LOGIC

	private void ShowBlackVeil()
	{
		_blackVeil.Visible = true;
		Tween fadeTween = CreateTween();
		fadeTween.TweenProperty(_blackVeil, "color:a", 0.5, 0.2);
		//fadeTween.TweenCallback(Callable.From(() => GetTree().Paused = true));//.SetDelay(2.0f);
	}

	#endregion

	#endregion
}

