using Common;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameLoop
{
    public class BootstrapGameState : IGameLoopState
    {
        private readonly GameStateMachine _stateMachine;
        private AsyncOperation _asyncLoad;
        private readonly CoroutineRunner _coroutineRunner;

        public BootstrapGameState(GameStateMachine stateMachine, CoroutineRunner coroutineRunner)
        {
            _stateMachine = stateMachine;
            _coroutineRunner = coroutineRunner;
        }

        public void Enter()
        {
            SceneManager.LoadScene("GameplayScene");
            _asyncLoad = SceneManager.LoadSceneAsync("GameplayScene", LoadSceneMode.Single);
            _coroutineRunner.StartCoroutine(CheckSceneLoaded());
            
        }
        private IEnumerator CheckSceneLoaded()
        {
            while (_asyncLoad != null && !_asyncLoad.isDone)
            {
                yield return null;
            }
            Exit();
        }

        public void Exit()
        {
            _stateMachine.SetState<GameplayInitializeState>();
        }
    }
}
