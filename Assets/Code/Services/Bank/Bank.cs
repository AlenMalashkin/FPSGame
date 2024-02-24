using System;
using Code.Data;
using Code.Services.SaveService;
using UnityEngine;

namespace Code.Services.Bank
{
	public class Bank : IBank
	{
		public event Action<int> MoneyChanged;

		public int Money
		{
			get => _progress.Progress.Money;
			set => _progress.Progress.Money = value >= 0 ? value : 0;
		}

		private IProgressModel _progress;
		private ISaveService _saveService;

		public Bank(IProgressModel progress, ISaveService saveService)
		{
			_progress = progress;
			_saveService = saveService;
		}
		
		public void GetMoney(int amount)
		{
			Money += amount;
			MoneyChanged?.Invoke(Money);
			_saveService.Save();
		}

		public bool SpendMoney(int amount)
		{
			if (Money >= amount)
			{
				Money -= amount;
				_saveService.Save();
				MoneyChanged?.Invoke(Money);
				return true;
			}

			return false;
		}
	}
}