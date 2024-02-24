using System;
using Code.UI.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.Windows.ChooseLevelWindow
{
	public class ChooseLevelWindow : WindowBase
	{
		[SerializeField] private Button closeButton;

		private IWindowService _windowService;

		[Inject]
		private void Construct(IWindowService windowService)
		{
			_windowService = windowService;
		}
		
		private void OnEnable()
		{
			closeButton.onClick.AddListener(Close);
		}

		private void OnDisable()
		{
			closeButton.onClick.RemoveListener(Close);
		}

		private void Close()
			=> _windowService.Close(WindowType.ChooseLevel);
	}
}