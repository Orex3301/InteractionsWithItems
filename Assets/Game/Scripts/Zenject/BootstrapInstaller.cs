using Common;
using Factories;
using GameLoop;
using UnityEngine;

namespace Zenject
{
	public class BootstrapInstaller : MonoInstaller
	{
        [SerializeField] private CoroutineRunner _coroutineRunner;
        [SerializeField] private Updater _updater;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<CoroutineRunner>().FromInstance(_coroutineRunner).AsSingle();
            Container.BindInterfacesAndSelfTo<Updater>().FromInstance(_updater).AsSingle();
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle().NonLazy();
        }
    }
}