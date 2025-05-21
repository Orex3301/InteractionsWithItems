using Inventory;

namespace ItemInteracting
{
    public class ItemInteractor
    {
        private IInteractingWithItemStrategy _currentStrategy;

        public bool CanInteract => _currentStrategy.CanInteract;

        public ItemInteractor(ItemsHolder itemsHolder, InventoryController inventoryController)
        {
            _currentStrategy = new DefaultItemInteracting(itemsHolder, inventoryController);
        }

        public void InteractWith(IInteractableItem item)
        {
            _currentStrategy.InteractWith(item);
        }

    }
}
