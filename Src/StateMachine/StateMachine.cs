
using Godot;
using System;

[GlobalClass]
public partial class StateMachine : State
{
	#region PROPERTIES

	#region EXPORTS

	#endregion

	#region FIELDS
	private State _currentState = null;
	protected State CurrentState
	{
		get { return _currentState; }
		set
		{
			if (value != _currentState)
			{
				if (_currentState != null)
					_currentState.ExitState();

				PreviousState = _currentState;
				_currentState = value;

				if (_currentState != null && IsInstanceValid(Owner) && !Owner.IsQueuedForDeletion())
				{
					_currentState.EnterState();
				}

				EmitSignal(SignalName.StateChanged, _currentState);
			}
		}
	}

	private State _previousState = null;
	protected State PreviousState
	{
		get { return _previousState; }
		set { _previousState = value; }
	}

	#endregion

	#region SIGNALS
	[Signal]
	public delegate void StateChangedEventHandler(State state);

	[Signal]
	public delegate void SubStateChangedEventHandler(State state);

	#endregion

	#endregion

	#region METHODS

	#region LIFECYCLE

	#region ENGINE
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		if (CurrentState != null && IsCurrentState())
		{
			CurrentState.Update(delta);
		}
	}

	// Called by State._Ready()
	public sealed override void _StateReady()
	{
		// Signal connections
		// Engine (automatically freed)

		// Customs (need to be freed manually)
		// Local and external (freed in _StateExitTree())
		StateChanged += (state) => OnStateChanged(state);
		if (ParentStateMachine != null)
		{
			SubStateChanged += (state) => ParentStateMachine.OnSubStateChanged(state);
		}

		// Children (freed in dedicated methods)

		// Logic
		SetToDefaultState();

		_StateMachineReady();
	}

	// Called by State._ExitTree()
	public sealed override void _StateExitTree()
	{
		_StateMachineExitTree();

		// Custom local signals freeing
		StateChanged -= (state) => OnStateChanged(state);
		if (ParentStateMachine != null)
		{
			SubStateChanged -= (state) => ParentStateMachine.OnSubStateChanged(state);
		}
	}
	// Called by StateMachine._StateReady()
	public virtual void _StateMachineReady()
	{
		return;
	}

	// Called by StateMachine._StateExitTree()
	public virtual void _StateMachineExitTree()
	{
		return;
	}
	#endregion

	#region STATE
	public sealed override void EnterState()
	{
		SetToDefaultState();
		StateMachineEnterState();
	}

	public sealed override void ExitState()
	{
		CurrentState = null;
		StateMachineExitState();
	}

	public virtual void StateMachineEnterState()
	{
		return;
	}

	public virtual void StateMachineExitState()
	{
		return;
	}
	#endregion

	#endregion

	#region ON_SIGNALS

	private void OnStateChanged(State state)
	{
		EmitSignal(SignalName.SubStateChanged, CurrentState);
	}

	private void OnSubStateChanged(State state)
	{
		EmitSignal(SignalName.SubStateChanged, CurrentState);
	}

	#endregion

	#region PUBLIC ACCESSORS

	public void SetState(State state)
	{
		CurrentState = state;
	}

	public void SetState(string stateStr)
	{
		CurrentState = GetNodeOrNull<State>(stateStr);
	}

	public State GetState()
	{
		return CurrentState;
	}

	// Todo throw error
	public string GetStateName()
	{
		return null != CurrentState ? CurrentState.Name : string.Empty;
	}

	public State GetPreviousState()
	{
		return PreviousState;
	}

	public string GetPreviousStateName()
	{
		return null != PreviousState ? PreviousState.Name : string.Empty;
	}

	#endregion

	#region LOGIC
	public void SetToDefaultState()
	{
		try
		{
			CurrentState = GetChild<State>(0);
		}
		catch (Exception e)
		{
			GD.PrintErr("Owner : " + Owner.Name);
			GD.PushError(e);
		}
	}
	#endregion

	#endregion
}
