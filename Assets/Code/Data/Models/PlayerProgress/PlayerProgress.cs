using System;
using System.Collections.Generic;
using Code.Data.Shop;

namespace Code.Data
{
	[Serializable]
	public class PlayerProgress
	{
		public int Money;
		public WeaponType WeaponEquipped = WeaponType.Pistol;
		public List<WeaponType> WeaponsBought = new List<WeaponType>()
		{
			WeaponType.Pistol
		};
	}
}