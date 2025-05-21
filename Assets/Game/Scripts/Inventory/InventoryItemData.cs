using UnityEngine;
namespace Inventory
{
	[CreateAssetMenu(menuName = "Config/Item", fileName = "New Item Config")]
	public class InventoryItemData : ScriptableObject
	{
		[field: SerializeField] public InventoryItem ItemPrefab { get; private set; }
	}
}