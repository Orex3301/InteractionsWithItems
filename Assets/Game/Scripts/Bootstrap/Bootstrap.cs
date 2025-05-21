using GameLoop;
using UnityEngine;
using Zenject;

namespace Bootstrap
{
    public class Bootstrap : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine;

        [Inject]
        public void Construct(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
            _gameStateMachine.SetState<BootstrapGameState>();
        }

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}
