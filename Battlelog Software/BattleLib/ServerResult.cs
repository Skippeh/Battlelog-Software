namespace BattleLib
{
	/// <summary>
	/// A server result from the server list.
	/// </summary>
	public class ServerResult
	{
		/// <summary>
		/// Gets or sets the level this server is running.
		/// </summary>
		/// <value>
		/// The level.
		/// </value>
		public GameLevel Level { get; set; }

		/// <summary>
		/// Gets or sets the game mode this server is running.
		/// </summary>
		/// <value>
		/// The game mode.
		/// </value>
		public GameMode GameMode { get; set; }

		/// <summary>
		/// Gets or sets the game preset this server is running.
		/// </summary>
		/// <value>
		/// The game preset.
		/// </value>
		public GamePreset GamePreset { get; set; }

		/// <summary>
		/// Gets or sets the URL to the server on BattleLog.
		/// </summary>
		/// <value>
		/// The URL.
		/// </value>
		public string Url { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ServerResult" /> class.
		/// </summary>
		/// <param name="level">The level this server is running.</param>
		/// <param name="gameMode">The game mode this server is running.</param>
		/// <param name="gamePreset">The game preset this server is running.</param>
		/// <param name="url">The URL to the server on BattleLog.</param>
		public ServerResult(GameLevel level, GameMode gameMode, GamePreset gamePreset, string url)
		{
			Level = level;
			GameMode = gameMode;
			GamePreset = gamePreset;
			Url = url;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ServerResult" /> class. Make sure to set the properties manually.
		/// </summary>
		public ServerResult()
		{
			
		}
	}
}