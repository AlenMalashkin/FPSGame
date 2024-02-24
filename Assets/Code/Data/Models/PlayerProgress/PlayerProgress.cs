using System;
using System.Collections.Generic;
using Code.Data.Models.Settings;
using Code.Data.Shop;

namespace Code.Data
{
	[Serializable]
	public class PlayerProgress
	{
		public int Money;
		public int RecordKillCount;
		public float RecordTime;
		public WeaponType WeaponEquipped = WeaponType.Pistol;
		public List<WeaponType> WeaponsBought = new List<WeaponType>
		{
			WeaponType.Pistol
		};
		public PlayerSettings Settings = new PlayerSettings();
	}
}