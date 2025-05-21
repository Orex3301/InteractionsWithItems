using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(menuName="Config/Inventory", fileName ="New Inventory Data")]
    public class InventoryData : ScriptableObject
    {
        [field: SerializeField] public List<InventoryItemData> Items { get; private set; }
        [field: SerializeField] public int MaxSize { get; private set; }

    }
}
