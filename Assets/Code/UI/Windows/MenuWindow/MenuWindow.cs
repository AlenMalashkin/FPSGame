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

		private IWindowService _windowService;
		
		[Inject]
		private void Construct(IWindowService windowService)
		{
			_windowService = windowService;
		}
		
		private void OnEnable()
		{
			chooseLevelButton.onClick.AddListener(OpenChooseLevelWindow);
			shopButton.onClick.AddListener(OpenShopWindow);
		}

		private void OnDisable()
		{
			chooseLevelButton.onClick.RemoveListener(OpenChooseLevelWindow);
			shopButton.onClick.RemoveListener(OpenShopWindow);
		}

		private void OpenChooseLevelWindow()
		{
			_windowService.Open(WindowType.ChooseLevel);
		}

		private void OpenShopWindow()
		{
			_windowService.Open(WindowType.Shop);
		}
	}
}