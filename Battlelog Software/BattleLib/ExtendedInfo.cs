namespace BattleLib
{
	/// <summary>
	/// Extended info from a <see cref="ServerResult"/>.
	/// </summary>
	public class ExtendedInfo
	{
		/// <summary>
		/// Gets or sets the banner URL.
		/// </summary>
		/// <value>
		/// The banner URL.
		/// </value>
		public string BannerUrl { get; set; }

		/// <summary>
		/// Gets or sets the server description.
		/// </summary>
		/// <value>
		/// The description.
		/// </value>
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the server message.
		/// </summary>
		/// <value>
		/// The message.
		/// </value>
		public string Message { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ExtendedInfo" /> class.
		/// </summary>
		/// <param name="bannerUrl">The banner URL.</param>
		/// <param name="description">The description.</param>
		/// <param name="message">The message.</param>
		public ExtendedInfo(string bannerUrl, string description, string message)
		{
			BannerUrl = bannerUrl;
			Description = description;
			Message = message;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ExtendedInfo" /> class. Make sure to set the properties manually.
		/// </summary>
		public ExtendedInfo()
		{
		}
	}
}