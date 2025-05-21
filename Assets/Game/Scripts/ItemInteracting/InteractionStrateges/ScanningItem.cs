namespace ItemInteracting
{
    public class ScanningItem : IInteractingWithItemStrategy
    {
        public bool CanInteract => throw new System.NotImplementedException();

        public void InteractWith(IInteractableItem item)
        {
            throw new System.NotImplementedException();
        }
    }
}