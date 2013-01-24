using System;
using System.Collections.Generic;

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
		/// Gets or sets the country abbrevation.
		/// </summary>
		/// <value>
		/// The country.
		/// </value>
		public string Country { get; set; }

		/// <summary>
		/// Gets or sets the extended info.
		/// </summary>
		/// <value>
		/// The extended info.
		/// </value>
		public ExtendedInfo ExtendedInfo { get; set; }

		/// <summary>
		/// Gets or sets the server's game expansion.
		/// </summary>
		/// <value>
		/// The game expansion.
		/// </value>
		public Expansion GameExpansion { get; set; }

		/// <summary>
		/// Gets or sets the server's supported game expansions.
		/// </summary>
		/// <value>
		/// The game expansions.
		/// </value>
		public List<Expansion> GameExpansions { get; set; }

		/// <summary>
		/// Gets or sets the game id.
		/// </summary>
		/// <value>
		/// The game id.
		/// </value>
		public long GameId { get; set; }

		/// <summary>
		/// Gets or sets the server's GUID.
		/// </summary>
		/// <value>
		/// The GUID.
		/// </value>
		public string Guid { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this server is password protected.
		/// </summary>
		/// <value>
		/// <c>true</c> if this server is password protected; otherwise, <c>false</c>.
		/// </value>
		public bool HasPassword { get; set; }

		/// <summary>
		/// Gets or sets the server IP.
		/// </summary>
		/// <value>
		/// The server IP.
		/// </value>
		public string IP { get; set; }

		/// <summary>
		/// Gets or sets the max allowed players on this server.
		/// </summary>
		/// <value>
		/// The max allowed players on the server.
		/// </value>
		public int MaxPlayers { get; set; }

		/// <summary>
		/// Gets or sets the amount of players on the server right now.
		/// </summary>
		/// <value>
		/// The amount of players on the server right now.
		/// </value>
		public int Players { get; set; }

		/// <summary>
		/// Gets or sets the server's name.
		/// </summary>
		/// <value>
		/// The server name.
		/// </value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the number of people in the queue.
		/// </summary>
		/// <value>
		/// The number of people in the queue.
		/// </value>
		public int QueuedPlayers { get; set; }

		/// <summary>
		/// Gets or sets the server ping.
		/// </summary>
		/// <value>
		/// The server ping.
		/// </value>
		public int Ping { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this server runs punkbuster.
		/// </summary>
		/// <value>
		/// <c>true</c> if this server runs punkbuster; otherwise, <c>false</c>.
		/// </value>
		public bool HasPunkbuster { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this server is ranked.
		/// </summary>
		/// <value>
		///   <c>true</c> if this server is ranked; otherwise, <c>false</c>.
		/// </value>
		public bool Ranked { get; set; }

		/// <summary>
		/// Gets or sets the region this server is in.
		/// </summary>
		/// <value>
		/// The server's region.
		/// </value>
		public Region Region { get; set; }

		/// <summary>
		/// Gets or sets the time span between now and when the server was last updated.
		/// </summary>
		/// <value>
		/// The time span between now and when the server was last updated.
		/// </value>
		public DateTime LastUpdated { get; set; }

		/// <summary>
		/// Gets or sets the port the server runs on.
		/// </summary>
		/// <value>
		/// The port the server runs on.
		/// </value>
		public int Port { get; set; }

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