using Code.Data;
using UnityEngine;

namespace Code.StaticData
{
	[CreateAssetMenu(fileName = "WindowConfigs", menuName = "WindowConfigs", order = 0)]
	public class WindowConfigs : ScriptableObject
	{
		public WindowConfig[] Configs;
	}
}