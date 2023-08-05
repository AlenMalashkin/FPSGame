using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure
{
	public interface ISceneLoader
	{
		void Load(string sceneName, Action onLoaded = null);
	}
	
	public class SceneLoader : ISceneLoader
	{
		private ICoroutineRunner _coroutineRunner;

		public SceneLoader(ICoroutineRunner coroutineRunner)
		{
			_coroutineRunner = coroutineRunner;
		}

		public void Load(string sceneName, Action onLoaded = null)
		{
			_coroutineRunner.StartCoroutine(LoadScene(sceneName, onLoaded));
		}
		
		private IEnumerator LoadScene(string sceneName, Action onLoaded)
		{
			AsyncOperation loadSceneAsync = SceneManager.LoadSceneAsync(sceneName);

			while (!loadSceneAsync.isDone)
				yield return null;
			
			onLoaded?.Invoke();
		}
	}
}