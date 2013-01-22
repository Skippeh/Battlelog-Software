namespace BattleLib
{
	/// <summary>
	/// A collection of search parameters used for finding specific servers.
	/// </summary>
	public class ServerFilter
	{
		/// <summary>
		/// Gets or sets the expansion(s) to search for.
		/// </summary>
		/// <value>
		/// The expansions.
		/// </value>
		public Expansion Expansions { get; set; }

		/// <summary>
		/// Gets or sets the game preset to search for.
		/// </summary>
		/// <value>
		/// The game preset.
		/// </value>
		public GamePreset GamePreset { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the server should be a premium-only server.
		/// </summary>
		/// <value>
		/// <c>true</c> if the server should be a premium-only server; otherwise, <c>false</c>.
		/// </value>
		public bool IsPremium { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the server should be ranked.
		/// </summary>
		/// <value>
		///   <c>true</c> if server should be ranked; otherwise, <c>false</c>.
		/// </value>
		public bool Ranked { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the server should have a map rotation.
		/// </summary>
		/// <value>
		/// <c>true</c> if the server should have a map rotation; otherwise, <c>false</c>.
		/// </value>
		public bool HasMapRotation { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the server should have a gamemode rotation.
		/// </summary>
		/// <value>
		/// <c>true</c> if the server should have a gamemode rotation; otherwise, <c>false</c>.
		/// </value>
		public bool HasGameModeRotation { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the server should be password protected.
		/// </summary>
		/// <value>
		/// <c>true</c> if the server should be password protected; otherwise, <c>false</c>.
		/// </value>
		public bool IsPasswordProtected { get; set; }

		/// <summary>
		/// Gets or sets the max allowed server ping. Set to 0 to disable.
		/// </summary>
		/// <value>
		/// The max allowed server ping.
		/// </value>
		public int MaxPing { get; set; }

		/// <summary>
		/// Gets or sets the max allowed players on the server at the same time.
		/// </summary>
		/// <value>
		/// The max players allowed on the server at the same time.
		/// </value>
		public int MaxPlayers { get; set; }

		/// <summary>
		/// Gets or sets the amount of free slots the server should have.
		/// </summary>
		/// <value>
		/// The amount of free slots.
		/// </value>
		public FreeSlots FreeSlots { get; set; }

		/// <summary>
		/// Gets or sets the game mode(s) the server should be running.
		/// </summary>
		/// <value>
		/// The game modes.
		/// </value>
		public GameMode GameModes { get; set; }

		/// <summary>
		/// Gets or sets the game map the server should be running.
		/// </summary>
		/// <value>
		/// The game map.
		/// </value>
		public GameLevel GameLevel { get; set; }
	}
}