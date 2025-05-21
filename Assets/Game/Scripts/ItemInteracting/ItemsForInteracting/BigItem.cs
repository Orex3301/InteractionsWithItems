using UnityEngine;

namespace ItemInteracting
{
    public class BigItem : MonoBehaviour, IInteractableItem
    {
        [field: SerializeField] public Transform Transform { get; private set; }
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
        [SerializeField] private Outline _outline;

        public virtual void OnLooking()
        {
            _outline.OutlineWidth = 4f;
        }

        public virtual void OnNotLooking()
        {
            _outline.OutlineWidth = 0f;
        }
    }
}
