namespace ItemInteracting
{
    public interface IInteractingWithItemStrategy
    {
        public bool CanInteract { get; }
        public void InteractWith(IInteractableItem item);
    }
}
