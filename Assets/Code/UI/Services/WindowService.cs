using System.Collections.Generic;
using Code.UI.Factory;
using Code.UI.Windows;
using UnityEngine;

namespace Code.UI.Services
{
	public class WindowService : IWindowService
	{
		private Dictionary<WindowType, WindowBase> _openedWindows = new Dictionary<WindowType, WindowBase>();
		
		private IUIFactory _uiFactory;
		
		public WindowService(IUIFactory uiFactory)
		{
			_uiFactory = uiFactory;
		}
		
		public void Open(WindowType type)
		{
			if (_openedWindows.ContainsKey(type)) 
				return;

			WindowBase openedWindow = _uiFactory.CreateWindow(type);
			_openedWindows.Add(type, openedWindow);
		}

		public void Close(WindowType type)
		{
			Object.Destroy(_openedWindows[type].gameObject);
			_openedWindows.Remove(type);
		}

		public void CloseAllOpenedWindows()
		{
			foreach (var key in _openedWindows.Keys)
			{
				Object.Destroy(_openedWindows[key].gameObject);
			}
			
			_openedWindows.Clear();
		}
	}
}