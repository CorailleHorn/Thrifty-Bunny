using Godot;
using System;

public partial class GameEvents : Node
{
	#region PROPERTIES
	#region SIGNALS
	[Signal]
	public delegate void CoinCounterChangedEventHandler(int count);
	[Signal]
	public delegate void OpenChestEventHandler();
	[Signal]
	public delegate void YouWinEventHandler();
	[Signal]
	public delegate void YouLooseEventHandler();
	#endregion
	#endregion

}
