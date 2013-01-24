using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BattleLib
{
	internal static class JsonHelper
	{
		/// <summary>
		/// Reads the <see cref="Expansion"/> from the given <see cref="JToken"/>.
		/// </summary>
		/// <param name="jToken">The <see cref="JToken"/>.</param>
		/// <returns></returns>
		public static Expansion ReadExpansion(JToken jToken)
		{
			// TODO: Implement method.
			return Expansion.Battlefield3;
		}

		/// <summary>
		/// Reads the <see cref="GameLevel"/> from the given <see cref="JToken"/>.
		/// </summary>
		/// <param name="jToken">The <see cref="JToken"/>.</param>
		/// <returns></returns>
		public static GameLevel ReadLevel(JToken jToken)
		{
			// TODO: Implement method.
			return GameLevel.OperationMetro;
		}

		/// <summary>
		/// Reads the <see cref="GamePreset"/> from the given <see cref="JToken"/>.
		/// </summary>
		/// <param name="jToken">The <see cref="JToken"/>.</param>
		/// <returns></returns>
		public static GamePreset ReadPreset(JToken jToken)
		{
			// TODO: Implement method.
			return GamePreset.Normal;
		}

		/// <summary>
		/// Reads the <see cref="Region"/> from the given <see cref="JToken"/>.
		/// </summary>
		/// <param name="jToken">The <see cref="JToken"/>.</param>
		/// <returns></returns>
		public static Region ReadRegion(JToken jToken)
		{
			Debug.WriteLine("Reading region, regions are not implemented properly yet.");
			int regionNumber = jToken.Value<int>();

			return (Region) regionNumber;
		}
	}
}