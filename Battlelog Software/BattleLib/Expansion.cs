using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleLib
{
	/// <summary>
	/// An enumeration of the available expansion packs for Battlefield 3.
	/// </summary>
	[Flags]
	public enum Expansion : byte
	{
		/// <summary>
		/// The base game.
		/// </summary>
		Battlefield3 = 1,

		/// <summary>
		/// The back to karkand expansion dlc.
		/// </summary>
		BackToKarkand = 2,

		/// <summary>
		/// The close quarters expansion.
		/// </summary>
		CloseQuarters = 4,

		/// <summary>
		/// The armored kill expansion.
		/// </summary>
		ArmoredKill = 8,

		/// <summary>
		/// The aftermath expansion.
		/// </summary>
		Aftermath = 16,
	}
}