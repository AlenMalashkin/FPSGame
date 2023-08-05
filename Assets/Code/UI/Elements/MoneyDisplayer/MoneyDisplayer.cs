using Code.Services.Bank;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.UI.Elements.MoneyDisplayer
{
	public class MoneyDisplayer : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI displayMoneyText;

		private IBank _bank;
		
		[Inject]
		private void Construct(IBank bank)
		{
			_bank = bank;
		}

		private void Awake()
		{
			displayMoneyText.text = _bank.Money + "";
		}

		private void OnEnable()
		{
			_bank.MoneyChanged += OnMoneyChanged;
		}

		private void OnDisable()
		{
			_bank.MoneyChanged -= OnMoneyChanged;	
		}

		private void OnMoneyChanged(int money)
		{
			displayMoneyText.text = money + "";
		}
	}
}