using Data.Player;
using Inventory;
using UnityEngine;

namespace Zenject
{
	public class GlobalInstaller : MonoInstaller
	{
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private PlayerModel _playerModel;
        [SerializeField] private InventoryData _inventoryData;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerConfig>().FromInstance(_playerConfig).AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerModel>().FromInstance(_playerModel).AsSingle();
            Container.BindInterfacesAndSelfTo<InventoryData>().FromInstance(_inventoryData).AsSingle();
        }
    }
}