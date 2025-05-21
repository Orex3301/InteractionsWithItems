using Common;
using Data.Player;
using Factories;
using Inventory;
using ItemInteracting;
using UnityEngine;

namespace GameLoop
{
    public class GameplayInitializeState : IGameLoopState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly PlayerFactory _playerFactory;
        private readonly InventoryData _inventoryData;

        private PlayerModel _playerModel;
        private InventoryController _inventoryController;
        private ItemInteractor _itemInteractor;
        private InteractableItemFinder _itemsFinder;
        private Updater _updater;

        public GameplayInitializeState(
            GameStateMachine stateMachine, 
            PlayerFactory playerFactory, 
            InventoryData inventoryData,
            Updater updater
            )
        {
            _stateMachine = stateMachine;
            _playerFactory = playerFactory;
            _inventoryData = inventoryData;
            _updater = updater;
        }

        public void Enter()
        {
            if (_playerModel == null)
                _playerModel = _playerFactory.Create();

            _itemsFinder = _playerModel.ItemsFinder;
            _inventoryController = new(_inventoryData, _playerModel, _updater, _playerModel.ItemsHolder);
            _itemInteractor = new ItemInteractor(_playerModel.ItemsHolder, _inventoryController);
            _itemsFinder.Initialize(_itemInteractor);

            Exit();
        }

        public void Exit()
        {
        }
    }
}
