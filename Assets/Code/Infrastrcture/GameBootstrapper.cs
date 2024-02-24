using Code.Infrastructure.StateMachine;
using Code.Infrastructure.StateMachine.States;
using Code.Services.InputService;
using UnityEngine;
using YG;
using Zenject;

namespace Code.Infrastructure
{
	public class GameBootstrapper : MonoBehaviour
	{
		private IGameStateMachine _gameStateMachine;
		private DiContainer _diContainer;

		[Inject]
		private void Construct(IGameStateMachine gameStateMachine, DiContainer diContainer)
		{
			_gameStateMachine = gameStateMachine;
			_diContainer = diContainer;
		}

		private void Start()
		{
			if (YandexGame.SDKEnabled)
				OnGetData();
			
			_gameStateMachine.Enter<BootstrapState>();
		}

		private void OnGetData()
		{
			if (YandexGame.EnvironmentData.isMobile)
			{
				_diContainer
					.BindInterfacesAndSelfTo<MobileInputService>()
					.AsSingle();
			}
			else
			{
				_diContainer
					.BindInterfacesAndSelfTo<DesctopInputService>()
					.AsSingle();
			}
		}

		public class Factory : PlaceholderFactory<GameBootstrapper>
		{
		}
	}
}