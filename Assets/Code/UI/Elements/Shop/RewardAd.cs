using System;
using Code.Services.Bank;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.Elements.Shop
{
	public class RewardAd : MonoBehaviour
	{
		[SerializeField] private Button reward;
		
		private IBank _bank;

		[Inject]
		private void Construct(IBank bank)
		{
			_bank = bank;
		}

		private void OnEnable()
		{
			reward.onClick.AddListener(GetReward);
		}

		private void OnDisable()
		{
			reward.onClick.RemoveListener(GetReward);
		}

		private void GetReward()
		{
			_bank.GetMoney(10);
		}
	}
}