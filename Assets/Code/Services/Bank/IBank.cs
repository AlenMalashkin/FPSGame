using System;

namespace Code.Services.Bank
{
	public interface IBank
	{
		event Action<int> MoneyChanged;
		int Money { get; set; }
		void GetMoney(int amount);
		bool SpendMoney(int amount);
	}
}