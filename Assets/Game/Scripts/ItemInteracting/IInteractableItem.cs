using UnityEngine;

namespace ItemInteracting
{
    public interface IInteractableItem
    {
        public Transform Transform { get; }
        public Rigidbody Rigidbody { get; }

        public void OnLooking();

        public void OnNotLooking();
    }
}
