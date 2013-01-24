using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using Redslide.HttpLib;
using Newtonsoft.Json;

namespace BattleLib
{
	/// <summary>
	/// Handles requests to the BattleLog website.
	/// </summary>
	public static class BattleRequest
	{
		/// <summary>
		/// Determines whether we're currently logged in. Queries the BattleLog website for a login form.
		/// </summary>
		/// <returns>
		///   <c>true</c> if we're currently logged in; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsLoggedIn()
		{
			var htmlDocument = new HtmlDocument();

			string html = HttpRequestHelper.GetResult("http://battlelog.battlefield.com", null);
			htmlDocument.LoadHtml(html);

			// If the below attribute is found, that means the login gate was found, meaning we are logged out.
			// The default value is true, meaning, if the gate attribute is not found, it means the login gate was not found, meaning we are logged in.
			bool isLoggedIn = htmlDocument.GetElementbyId("gate") == null;

			return isLoggedIn;
		}

		/// <summary>
		/// Log into BattleLog with the specified account details. Returns a boolean determining whether the login was successful or not.
		/// </summary>
		/// <param name="username">The username. Most likely an email.</param>
		/// <param name="pass">The password.</param>
		/// <returns></returns>
		public static bool Login(string username, string pass)
		{
			bool waiting = true;
			string loginResult = string.Empty;

			Action<string> onSuccessCallback = (result) =>
				{
					loginResult = result;
					waiting = false;
				};

			Request.Post("https://battlelog.battlefield.com/all/gate/login/", new
				{
					email = username,
					password = pass,
					submit = "Sign In"
				}, onSuccessCallback);

			while (waiting)
			{
				// Wait for the callback.
				Thread.Sleep(1);
			}

			// For debugging purposes.
			StreamWriter file = File.CreateText("Output.html");
			file.Write(loginResult);
			file.Close();
			//Process.Start("Output.html");

			var htmlDocument = new HtmlDocument();
			htmlDocument.LoadHtml(loginResult);

			// Select the login form on the BattleLog login page. Will be null if we logged in successfully.
			var node = htmlDocument.DocumentNode.SelectSingleNode("/html/body/div/div/div[2]/div/div/div[2]/form");

			// If the node is null, the login form wasn't found, because we're on the BattleLog front page.
			return node == null;
		}

		/// <summary>
		/// Requests the server list and returns found servers in a list.
		/// </summary>
		/// <param name="filter">The server filter to use.</param>
		/// <param name="offset">The offset starting from 1. Higher = servers that would occur further down the server browser list.</param>
		/// <param name="count">The number of servers to query for. Unsure what the max count is.</param>
		/// <returns></returns>
		public static List<ServerResult> RequestServerList(ServerFilter filter, int offset = 1, int count = 15)
		{
			string json = GetJsonResponse(string.Format("http://battlelog.battlefield.com/bf3/servers/getAutoBrowseServers/?offset={0}&count={1}", offset, count));

			var result = new List<ServerResult>();

			var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

			if (dict["type"].ToString() == "success")
			{
				var data = (JArray) dict["data"];

				for (int i = 0; i < data.Count; ++i)
				{
					var info = (JObject) data[i];

					var sr = new ServerResult();

					sr.Country = info["country"].Value<String>();
					
					// Get all values for ExtendedInfo.
					var extendedInfo = info["extendedInfo"];
					string bannerUrl = extendedInfo["bannerUrl"].Value<string>();
					string description = extendedInfo["desc"].Value<string>();
					string message = extendedInfo["message"].Value<string>();
					sr.ExtendedInfo = new ExtendedInfo(bannerUrl, description, message);

					sr.GameExpansion = JsonHelper.ReadExpansion(info["gameExpansion"]);

					// Get all expansions.
					var jsonExpansions = info["gameExpansions"].ToList();

					sr.GameExpansions = new List<Expansion>(); // Instantiate the list so we can add items to it.
					jsonExpansions.ForEach(expansion => sr.GameExpansions.Add(JsonHelper.ReadExpansion(expansion))); // Add all the expansions to the server result's GameExpansions list.

					sr.GameId = info["gameId"].Value<long>();

					sr.Guid = info["guid"].Value<string>();

					sr.Url = "http://battlelog.battlefield.com/bf3/servers/show/" + sr.Guid;

					sr.HasPassword = info["hasPassword"].Value<bool>();

					sr.IP = info["ip"].Value<string>();

					sr.Level = JsonHelper.ReadLevel(info["map"]);

					sr.MaxPlayers = info["maxPlayers"].Value<int>();

					sr.Players = info["numPlayers"].Value<int>();

					sr.QueuedPlayers = info["numQueued"].Value<int>();

					sr.Name = info["name"].Value<string>();

					sr.Ping = info["ping"].Value<int>();

					sr.Port = info["port"].Value<int>();

					sr.GamePreset = JsonHelper.ReadPreset(info["preset"]);

					sr.HasPunkbuster = info["punkbuster"].Value<bool>();

					sr.Ranked = info["ranked"].Value<bool>();

					sr.Region = JsonHelper.ReadRegion(info["region"]);

					sr.LastUpdated = DateTime.Now - (DateTime.Now - DateTime.FromBinary(info["updatedAt"].Value<long>()));

					result.Add(sr);
				}
			}
			else
			{
				throw new ServerException("The server did not succeed in supplying server list. (type = " + dict["type"].ToString() + ")");
			}

			return result;
		}

		/// <summary>
		/// Gets a json response from the battlelog server by adding a header saying we want it in json.
		/// </summary>
		/// <param name="url">The URL.</param>
		/// <returns></returns>
		public static string GetJsonResponse(string url)
		{
			string response = string.Empty;

			Action<string> onSuccessCallback = s => response = s;

			Request.Get(url, onSuccessCallback, new WebHeaderCollection()
				{
					{"X-Requested-With", "XMLHttpRequest"} // Tell battlelog we want it in json.
				});

			while (response == string.Empty)
			{
				Thread.Sleep(1); // Wait for the response.
			}

			return response;
		}
	}
}