using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleLib;

namespace Testing
{
	static class Program
	{
		static void Main(string[] args)
		{
			bool loggedIn = BattleRequest.IsLoggedIn();

			if (!loggedIn)
			{
				Console.Write("Username: ");
				string username = Console.ReadLine();

				Console.Write("Password: ");
				var password = ReadLineCensored();

				if (!BattleRequest.Login(username, password))
				{
					Console.WriteLine("Could not login with specified account details. Invalid username or password.");
					return;
				}

				Console.WriteLine("Successfully logged onto BattleLog!");
				Console.WriteLine("\n");
			}

			while (true)
			{
				Console.WriteLine("1. View a list of servers");
				Console.WriteLine("2. Join a server.");
				Console.WriteLine("3. Check logged in status");
				Console.WriteLine("4. Exit");
				Console.Write("\n> ");

				string input = Console.ReadLine();
				int selection;

				if (int.TryParse(input, out selection))
				{
					switch (selection)
					{
						case 1:
							{
								var sw = Stopwatch.StartNew();
								List<ServerResult> servers = BattleRequest.RequestServerList(null);

								foreach (var server in servers)
								{
									Console.WriteLine(string.Format("{0} - {1}:{2} - {3}/{4}/{5} (plrs/max/queued) - last updated {6} sec ago", server.Name.Length > 20
										                                                                                                            ? server.Name.Substring(0, 20) + "..."
										                                                                                                            : server.Name,
									                                server.IP, server.Port, server.Players, server.MaxPlayers, server.QueuedPlayers, server.LastUpdated.TimeOfDay.Seconds));
								}
								sw.Stop();

								Console.WriteLine("Time to query servers: " + sw.Elapsed.TotalMilliseconds.ToString(CultureInfo.InvariantCulture) + "ms");
								Console.ReadKey(true);

								break;
							}
						case 2:
							{
								break;
							}
						case 3:
							{
								bool loggedInStatus = BattleRequest.IsLoggedIn();
								Console.WriteLine("Current logged in status: " + loggedInStatus);
								Console.ReadKey(true);

								break;
							}
						case 4:
							{
								return;
							}
						default:
							{
								Console.Write("Invalid input.");
								Console.ReadKey(true);
								break;
							}
					}
				}

				Console.Clear();
			}
		}

		private static string ReadLineCensored()
		{
			string input = string.Empty;

			// Censor console input by intercepting the entered key and adding it to the input string. Break out of the loop if the entered key is the enter button.
			ConsoleKeyInfo info;
			while ((info = Console.ReadKey(true)).Key != ConsoleKey.Enter)
			{
				input += info.KeyChar;
			}

			Console.WriteLine(); // Copy the "new line after input" behaviour of Console.Read methods.

			return input;
		}
	}
}