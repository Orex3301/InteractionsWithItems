using Data.Player;
using UnityEngine;
using Zenject;

namespace Factories
{
    public class PlayerFactory
    {
        private readonly PlayerModel _playerModel;
        private readonly PlayerConfig _config;

        [Inject]
        public PlayerFactory(PlayerModel playerModel, PlayerConfig config)
        {
            _playerModel = playerModel;
            _config = config;
        }

        public PlayerModel Create()
        {
            PlayerModel player = GameObject.Instantiate(_playerModel, _config.StartPosition, Quaternion.identity);
            player.Initialize(_config);
            return player;
        }
    }
}
