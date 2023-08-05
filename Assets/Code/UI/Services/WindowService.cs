using System;
using Code.UI.Factory;
using Code.UI.Windows;

namespace Code.UI.Services
{
	public class WindowService : IWindowService
	{
		private IUIFactory _uiFactory;
		
		public WindowService(IUIFactory uiFactory)
		{
			_uiFactory = uiFactory;
		}
		
		public void Open(WindowType type)
		{
			switch (type)
			{
				case WindowType.Menu:
					_uiFactory.CreateMenu();
					break;
				case WindowType.ChooseLevel:
					_uiFactory.CreateChooseLevel();
					break;
				case WindowType.Shop:
					_uiFactory.CreateShop();
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(type), type, null);
			}
		}
	}
}