using Code.Services.Bank;
using Zenject;

namespace Code.Logic.Loot
{
	public class MoneyLoot : Loot
	{
		private IBank _bank;
		
		[Inject]
		private void Construct(IBank bank)
		{
			_bank = bank;
		}
		
		public override void Collect()
		{
			_bank.GetMoney(1);
			Destroy(gameObject);
		}
	}
}