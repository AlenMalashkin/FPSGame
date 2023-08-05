using UnityEngine;

namespace Code.Extensions.DataExtensions
{
	public static class DataExtensions
	{
		public static string ToJson(this object json)
			=> JsonUtility.ToJson(json);

		public static T FromJson<T>(this string json)
			=> JsonUtility.FromJson<T>(json);
	}
}