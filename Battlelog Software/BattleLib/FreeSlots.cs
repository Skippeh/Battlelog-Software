using System;

namespace BattleLib
{
	/// <summary>
	/// An enumeration of the amount of free slots a server should have.
	/// </summary>
	[Flags]
	public enum FreeSlots : byte
	{
		/// <summary>
		/// The server is full.
		/// </summary>
		Full = 1,

		/// <summary>
		/// SThe server has 1-5 free slots.
		/// </summary>
		OneToFive = 2,

		/// <summary>
		/// The server has 6-10 free slots.
		/// </summary>
		SixToTen = 4,

		/// <summary>
		/// SThe server has 10 or more free slots.
		/// </summary>
		TenPlus = 8,

		/// <summary>
		/// The server is empty.
		/// </summary>
		Empty = 16,
	}
}