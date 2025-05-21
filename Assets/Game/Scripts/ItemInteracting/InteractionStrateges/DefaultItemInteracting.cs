using Inventory;

namespace ItemInteracting
{
    public class DefaultItemInteracting : IInteractingWithItemStrategy
    {
        private readonly ItemsHolder _itemsHolder;
        private readonly InventoryController _inventoryController;

        public bool CanInteract => !_itemsHolder.IsHolding && !_inventoryController.ItemInHand;

        public DefaultItemInteracting(ItemsHolder itemsHolder, InventoryController inventoryController)
        {
            _itemsHolder = itemsHolder;
            _inventoryController = inventoryController;
        }
        public void InteractWith(IInteractableItem item)
        {
            if (item is BigItem)
            {
                PickUp(item as BigItem);
                _inventoryController.SelectItem(-1);
            }
            else
            {
                PutIntoInventory(item as SmallItem);
            }
        }

        private void PickUp(BigItem item)
        {
            _itemsHolder.Hold(item);
        }
        
        public void PutIntoInventory(SmallItem item)
        {
            _inventoryController.SetItem(item);
        }
    }
}