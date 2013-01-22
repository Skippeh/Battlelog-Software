using System;

namespace BattleLib
{
	/// <summary>
	/// An enumeration of the available game modes.
	/// </summary>
	[Flags]
	public enum GameMode : short
	{
		/// <summary>
		/// The Conquest Large gamemode.
		/// </summary>
		ConquestLarge = 1,

		/// <summary>
		/// The Conquest gamemode.
		/// </summary>
		Conquest = 2,

		/// <summary>
		/// The Conquest Assault Large gamemode.
		/// </summary>
		ConquestAssaultLarge = 4,

		/// <summary>
		/// The Conquest Assault gamemode.
		/// </summary>
		ConquestAssault = 8,

		/// <summary>
		/// The Rush gamemode.
		/// </summary>
		Rush = 16,

		/// <summary>
		/// The Squad Rush gamemode.
		/// </summary>
		SquadRush = 32,

		/// <summary>
		/// The Squad DM gamemode.
		/// </summary>
		SquadDM = 64,

		/// <summary>
		/// The Team DM gamemode.
		/// </summary>
		TeamDM = 128,

		/// <summary>
		/// The Team DM 16 players gamemode.
		/// </summary>
		TeamDM16Players = 256,

		/// <summary>
		/// The Gun Master gamemode.
		/// </summary>
		GunMaster = 512,

		/// <summary>
		/// The Conquest Domination gamemode.
		/// </summary>
		ConquestDomination = 1024,

		/// <summary>
		/// The Tank Superiority gamemode.
		/// </summary>
		TankSuperiority = 2048,

		/// <summary>
		/// The Scavenger gamemode.
		/// </summary>
		Scavenger = 4096,
	}
}