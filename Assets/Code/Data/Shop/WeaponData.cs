using System;
using UnityEngine;

namespace Code.Data.Shop
{
	[Serializable]
	public class WeaponData
	{
		public GameObject weaponPrefab;
		public WeaponType Type;
		public Sprite Sprite;
		public int Cost;
		public int Damage;
		public float FireRate;
		public float ReloadTime;
		public int BulletsCount;
		public int BulletsInClip;
	}
}