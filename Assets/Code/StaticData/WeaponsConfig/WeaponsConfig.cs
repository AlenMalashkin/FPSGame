using Code.Data.Shop;
using UnityEngine;

namespace Code.StaticData.WeaponsConfig
{
	[CreateAssetMenu(fileName = "WeaponsConfig", menuName = "WeaponsConfig", order = 2)]
	public class WeaponsConfig : ScriptableObject
	{
		public WeaponData[] WeponsData;
	}
}