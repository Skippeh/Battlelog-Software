using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using HtmlAgilityPack;
using Redslide.HttpLib;

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
				Thread.Sleep(10);
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
		/// <returns></returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public static List<ServerResult> RequestServerList(ServerFilter filter)
		{


			throw new NotImplementedException();
		}
	}
}