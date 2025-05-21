using Common;
using Data.Player;
using Factories;
using Inventory;
using System.Collections.Generic;
using Zenject;

namespace GameLoop
{
    public class GameStateMachine
    {
        private readonly Dictionary<System.Type, IGameLoopState> _states;

        [Inject]
        public GameStateMachine(
            PlayerFactory playerFactory,
            PlayerConfig playerConfig,
            CoroutineRunner coroutineRunner,
            InventoryData inventoryData,
            Updater updater
            )
        {
            _states = new Dictionary<System.Type, IGameLoopState>
            {
                { typeof(BootstrapGameState), new BootstrapGameState(this, coroutineRunner) },
                { typeof(GameplayInitializeState), new GameplayInitializeState(this, playerFactory, inventoryData, updater) }
            };
        }

        public void SetState<T>() where T : IGameLoopState
        {
            _states[typeof(T)].Enter();
        }
    }
}
