using Code.Data;
using UnityEngine;

namespace Code.StaticData.HUDConfigs
{
	[CreateAssetMenu(fileName = "HUDConfigs", menuName = "HUDConfigs", order = 5)]
	public class HUDConfigs : ScriptableObject
	{
		public HUDConfig[] HUDConfigsList;
	}
}