using Data;
using Inventory;
using UnityEngine;

namespace ItemInteracting
{
    public class SmallItem : InventoryItem, IScannable
    {
        [field: SerializeField] public string Name { get; private set; }

        public override void OnTaked()
        {
            
        }

        public override void OnUnTaked()
        {
            
        }
    }
}
