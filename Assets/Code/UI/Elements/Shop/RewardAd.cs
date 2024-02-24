using System;
using Code.Services.Bank;
using UnityEngine;
using UnityEngine.UI;
using YG;
using Zenject;

namespace Code.UI.Elements.Shop
{
	public class RewardAd : MonoBehaviour
	{
		[SerializeField] private int rewardForVideo = 10;
		[SerializeField] private Button reward;
		
		private IBank _bank;

		[Inject]
		private void Construct(IBank bank)
		{
			_bank = bank;
		}

		private void OnEnable()
		{
			YandexGame.CloseVideoEvent += GetReward;
		}

		private void OnDisable()
		{
			YandexGame.CloseVideoEvent -= GetReward;

		}

		private void GetReward()
		{
			_bank.GetMoney(rewardForVideo);
		}
	}
}