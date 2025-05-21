using ItemInteracting;
using Player;
using UnityEngine;

namespace Data.Player
{
	public class PlayerModel : MonoBehaviour
	{
        [SerializeField] private Camera _camera;
        [field: SerializeField] public MovementHandler MovementHandler { get; private set; }
        [field: SerializeField] public InteractableItemFinder ItemsFinder { get; private set; }
        [field: SerializeField] public ItemsHolder ItemsHolder { get; private set; }
        [field: SerializeField] public Transform HandPoint { get; private set; }

        public void Initialize(PlayerConfig playerConfig)
        {
            MovementHandler.Initialize(playerConfig, _camera);
            Camera.SetupCurrent(_camera);
        }
    }
}