using Code.UI.Windows;

namespace Code.UI.Services
{
	public interface IWindowService
	{
		void Open(WindowType type);
		void Close(WindowType type);
		void CloseAllOpenedWindows();
	}
}