using UnityEngine;

namespace ItemInteracting
{
    public class InteractableItemFinder : MonoBehaviour
    {
        [SerializeField] private float rayDistance = 5f;
        private IInteractableItem _currentInteractable;
        private ItemInteractor _itemInteractor;


        public void Initialize(ItemInteractor itemInteractor)
        {
            _itemInteractor = itemInteractor;
        }

        public void Update()
        {
            if (_itemInteractor.CanInteract)
            {
                PerformRaycast();
                if (_currentInteractable != null)
                {
                    CheckInteract();
                }
            }
            else
            {
                if (_currentInteractable != null)
                {
                    _currentInteractable.OnNotLooking();
                    _currentInteractable = null;
                }
            }
        }

        private void PerformRaycast()
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                IInteractableItem interactable = hit.collider.GetComponent<IInteractableItem>();

                if (interactable != null)
                {
                    if(interactable != _currentInteractable)
                    {
                        if (_currentInteractable != null) _currentInteractable.OnNotLooking();

                        _currentInteractable = interactable;
                        _currentInteractable.OnLooking();
                    }
                }
                else
                {
                    if (_currentInteractable != null) _currentInteractable.OnNotLooking();
                    _currentInteractable = null;
                }
            }
            else
            {
                if (_currentInteractable != null) _currentInteractable.OnNotLooking();
                _currentInteractable = null;
            }
        }

        private void CheckInteract()
        {
            if (Input.GetKeyDown(KeyCode.E) && _currentInteractable != null && _itemInteractor.CanInteract)
            {
                _itemInteractor.InteractWith(_currentInteractable);
                _currentInteractable.OnNotLooking();
                _currentInteractable = null;
            }
        }
    }
}
