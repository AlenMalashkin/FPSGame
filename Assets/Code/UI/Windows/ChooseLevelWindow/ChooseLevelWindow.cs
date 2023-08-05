using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Windows.ChooseLevelWindow
{
	public class ChooseLevelWindow : WindowBase
	{
		[SerializeField] private Button closeButton;

		private void OnEnable()
		{
			closeButton.onClick.AddListener(Close);
		}

		private void OnDisable()
		{
			closeButton.onClick.RemoveListener(Close);
		}

		private void Close()
			=> Destroy(gameObject);
	}
}