using DG.Tweening;
using UnityEngine;

namespace ItemInteracting
{
	public class ItemsHolder : MonoBehaviour
	{
		[SerializeField] private Transform _holdingPoint;

		private BigItem _currentItem;

		public bool IsHolding => _currentItem != null;

		public void Hold(BigItem item)
		{
			if (_currentItem != null)
			{
				DropItem();
			}

			_currentItem = item;
			_currentItem.Transform.SetParent(_holdingPoint);
			_currentItem.Rigidbody.isKinematic = true;
			
			_currentItem.Transform.DOMove(_holdingPoint.position, 0.1f);
			_currentItem.Transform.localRotation = Quaternion.identity;
		}

		private void DropItem()
		{
            _currentItem.Transform.SetParent(null);
            _currentItem.Rigidbody.isKinematic = false;
			_currentItem = null;
        }

        private void Update()
        {
            if (_currentItem != null)
			{
				if (Input.GetKeyDown(KeyCode.Q))
					DropItem();
				else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.R))
					RotateItem(90);
				else if (Input.GetKeyDown(KeyCode.R))
					RotateItem(45);
			}
        }

		private void RotateItem(float angle)
		{
			_currentItem.Transform.DORotate(_currentItem.Transform.eulerAngles + new Vector3(0, angle, 0), 0.1f);
		}
    }
}