using System;

namespace BattleLib
{
	/// <summary>
	/// An enumeration of the available game levels.
	/// </summary>
	[Flags]
	public enum GameLevel
	{
		/// <summary>
		/// The grand bazaar level.
		/// </summary>
		GrandBazaar = 1,

		/// <summary>
		/// The tehran highway level.
		/// </summary>
		TehranHighway = 2,

		/// <summary>
		/// The caspian border level.
		/// </summary>
		CaspianBorder = 4,

		/// <summary>
		/// The seine crossing level.
		/// </summary>
		SeineCrossing = 8,

		/// <summary>
		/// The operation firestorm level.
		/// </summary>
		OperationFirestorm = 16,

		/// <summary>
		/// The damavand peak level.
		/// </summary>
		DamavandPeak = 32,

		/// <summary>
		/// The nosehair canals level.
		/// </summary>
		NosehairCanals = 64,

		/// <summary>
		/// The kharg island level.
		/// </summary>
		KhargIsland = 128,

		/// <summary>
		/// The operation metro level.
		/// </summary>
		OperationMetro = 256,

		/// <summary>
		/// The strike at karkand level.
		/// </summary>
		StrikeAtKarkand = 512,

		/// <summary>
		/// The gulf of oman level.
		/// </summary>
		GulfOfOman = 1024,

		/// <summary>
		/// The sharqi peninsula level.
		/// </summary>
		SharqiPeninsula = 2048,

		/// <summary>
		/// The wake island level.
		/// </summary>
		WakeIsland = 4096,

		/// <summary>
		/// The scrap metal level.
		/// </summary>
		ScrapMetal = 8192,

		/// <summary>
		/// The operation925 level.
		/// </summary>
		Operation925 = 16384,

		/// <summary>
		/// The donya fortress level.
		/// </summary>
		DonyaFortress = 32768,

		/// <summary>
		/// The ziba tower level.
		/// </summary>
		ZibaTower = 65536,

		/// <summary>
		/// The alborz mountains level.
		/// </summary>
		AlborzMountains = 131072,

		/// <summary>
		/// The bandar desert level.
		/// </summary>
		BandarDesert = 262144,

		/// <summary>
		/// The armored shield level.
		/// </summary>
		ArmoredShield = 524288,

		/// <summary>
		/// The death valley level.
		/// </summary>
		DeathValley = 1048576,

		/// <summary>
		/// The markaz monolith level.
		/// </summary>
		MarkazMonolith = 2097152,

		/// <summary>
		/// The azadi palace level.
		/// </summary>
		AzadiPalace = 4194304,

		/// <summary>
		/// The epicenter level.
		/// </summary>
		Epicenter = 8388608,

		/// <summary>
		/// The talah market level.
		/// </summary>
		TalahMarket = 16777216,
	}
}