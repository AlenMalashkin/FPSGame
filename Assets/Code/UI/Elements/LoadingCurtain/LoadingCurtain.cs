using System.Collections;
using UnityEngine;

namespace Code.UI.Elements.LoadingCurtain
{
	public class LoadingCurtain : MonoBehaviour, ILoadingCurtain
	{
		[SerializeField] private CanvasGroup curtain;

		public void Show()
		{
			gameObject.SetActive(true);
			curtain.alpha = 1;
		}

		public void Hide()
			=> gameObject.SetActive(false);

		private IEnumerator FadeOutCoroutine()
		{
			while (curtain.alpha > 0)
			{
				curtain.alpha -= 0.03f;
				yield return new WaitForSeconds(0.01f);
			}
			
			gameObject.SetActive(false);
		}
	}
}