
using Godot;
using System;

[GlobalClass]
public partial class State : Node
{

	#region PROPERTIES
	#region ONREADY
	public StateMachine ParentStateMachine = null;

	#endregion
	#endregion

	#region METHODS

	#region OVERRIDE
	public sealed override void _Ready()
	{
		base._Ready();

		// On ready
		try
		{
			ParentStateMachine = GetParentOrNull<StateMachine>();
		}
		catch (Exception e)
		{
			GD.PushError($"Error while loading state (Owner : '{Owner.Name}') : ", e);
		}

		_StateReady();
	}

	public sealed override void _ExitTree()
	{
		_StateExitTree();

		base._ExitTree();
	}

	#endregion

	#region VIRTUAL

	// Called by State._Ready()
	public virtual void _StateReady()
	{
		return;
	}

	// Called by State._ExitTree()
	public virtual void _StateExitTree()
	{
		return;
	}

	public virtual void EnterState()
	{
		return;
	}

	public virtual void ExitState()
	{
		return;
	}

	public virtual void Update(double delta)
	{
		return;
	}

	/// <summary>
	/// Renvoi si le state est "séléctionné" par la statemachine parente, si la statemachine parente n'existe pas, c'est que cet état est racine donc forcément séléctionné
	/// </summary>
	/// <returns></returns>
	public virtual bool IsCurrentState()
	{
		return ParentStateMachine == null || ParentStateMachine.GetState() == this;
	}

	#endregion

	#endregion
}
