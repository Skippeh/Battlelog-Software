using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Redslide.HttpLib;

namespace BattleLib
{
	/// <summary>
	/// Helper methods for the Redslide.HttpLib library.
	/// </summary>
	internal static class HttpRequestHelper
	{
		/// <summary>
		/// Makes the asynchronous method from RedSlide.HttpLib synchronous. Returns the result from the given url and parameters.
		/// </summary>
		/// <param name="url">The URL to make the request to.</param>
		/// <param name="parameters">The parameters, if any.</param>
		/// <returns></returns>
		public static string GetResult(string url, object parameters)
		{
			string returnResult = string.Empty;

			Action<string> onSuccessCallback = (result) =>
				{
					returnResult = result;
				};

			Request.Get(url, parameters, onSuccessCallback);

			while (returnResult == string.Empty)
			{
				// Wait for the result to be retrieved.
				Thread.Sleep(1);
			}

			return returnResult;
		}
	}
}