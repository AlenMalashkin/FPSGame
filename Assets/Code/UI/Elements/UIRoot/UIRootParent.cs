using Code.UI.Factory;
using UnityEngine;
using Zenject;

namespace Code.UI.Elements.UIRoot
{
	public class UIRootParent : MonoBehaviour
	{
		private IUIFactory _uiFactory;

		[Inject]
		private void Construct(IUIFactory uiFactory)
		{
			_uiFactory = uiFactory;
		}

		private void Awake()
		{
			_uiFactory.CreateRoot(transform);
		}
	}
}