using System;
using Audio;
using Code.UI.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.Windows.MenuWindow
{
	public class MenuWindow : WindowBase
	{
		[SerializeField] private Button chooseLevelButton;
		[SerializeField] private Button shopButton;
		[SerializeField] private Button settingsButton;
		
		private IWindowService _windowService;
		private MusicPlayer _musicPlayer;
		
		[Inject]
		private void Construct(IWindowService windowService, MusicPlayer musicPlayer)
		{
			_windowService = windowService;
			_musicPlayer = musicPlayer;
		}
		
		private void OnEnable()
		{
			chooseLevelButton.onClick.AddListener(OpenChooseLevelWindow);
			shopButton.onClick.AddListener(OpenShopWindow);
			settingsButton.onClick.AddListener(OpenSettingsWindow);
		}

		private void OnDisable()
		{
			chooseLevelButton.onClick.RemoveListener(OpenChooseLevelWindow);
			shopButton.onClick.RemoveListener(OpenShopWindow);
			settingsButton.onClick.RemoveListener(OpenSettingsWindow);
		}

		private void OpenChooseLevelWindow()
		{
			_windowService.Open(WindowType.ChooseLevel);
		}

		private void OpenShopWindow()
		{
			_windowService.Open(WindowType.Shop);
		}

		private void OpenSettingsWindow()
		{
			_windowService.Open(WindowType.Settings);
		}
	}
}