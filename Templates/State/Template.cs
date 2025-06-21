// meta-name: State template
// meta-description: Default template for State Nodes
// meta-default: true

using _BINDINGS_NAMESPACE_;
using System;

public partial class _CLASS_ : _BASE_
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
	private Node _nodeOwner = null;
	#endregion

	#endregion

	#region METHODS

	#region OVERRIDE

	// Called by State._Ready()
	public override void _StateReady()
	{
		try
		{
			// On ready
			_nodeOwner = GetOwner<Node>();

			// Signal connections
			// Engine (automatically freed)

			// Customs (need to be freed manually)
			// Local and external emitter (freed in _ExitTree())

			// Children emitter (automatically freed))

			// Logic
		}
		catch (Exception e)
		{
			GD.PushError($"Error while loading state _CLASS_ (Owner : '{Owner.Name}') : ", e);
		}
	}

	// Called by State._ExitTree()
	public override void _StateExitTree()
	{
		try
		{
			// Custom local and external signals freeing

		}
		catch (Exception e)
		{
			GD.PushError($"Error while unloading state _CLASS_ (Owner : '{Owner.Name}') : ", e);
		}
	}

	public override void EnterState()
	{

	}

	public override void ExitState()
	{

	}

	public override void Update(double delta)
	{

	}

	#endregion

	#region ON_SIGNALS

	#endregion

	#region LOGIC

	#endregion

	#endregion
}
