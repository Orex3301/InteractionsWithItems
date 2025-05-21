using Common;
using Data.Player;
using DG.Tweening;
using ItemInteracting;
using UnityEngine;

namespace Inventory
{
    public class InventoryController
    {
        private readonly InventoryData _inventoryData;
        private InventoryItem[] _items;
        private int _activeItemId;
        private Transform _handPoint;
        private readonly ItemsHolder _itemsHolder;

        public bool ItemInHand => _activeItemId != -1 && _items[_activeItemId] != null;

        public InventoryController(
            InventoryData inventoryData,
            PlayerModel playerModel,
            Updater updater,
            ItemsHolder itemsHolder
            )
        {
            _inventoryData = inventoryData;
            _handPoint = playerModel.HandPoint;
            _itemsHolder = itemsHolder;
            updater.Updated += Update;

            _items = new InventoryItem[inventoryData.MaxSize];
            int counter = 0;
            foreach (InventoryItemData itemData in _inventoryData.Items)
            {
                if (counter >= inventoryData.MaxSize) break;

                InventoryItem item = GameObject.Instantiate(itemData.ItemPrefab, _handPoint.position, Quaternion.identity);
                item.Rigidbody.isKinematic = true;
                item.gameObject.SetActive(false);
                item.Transform.SetParent(_handPoint);
                _items[counter++] = item;
            }

            SelectItem(0);
        }

        public void SetItem(InventoryItem item)
        {
            if (_activeItemId < 0)
            {
                int freeSlot = FindFreeSlot();
                if (freeSlot == -1) return;
                else _activeItemId = freeSlot;
            }

            if (_items[_activeItemId] != null)
            {
                DropItem();
            }

            _items[_activeItemId] = item;
            _items[_activeItemId].Rigidbody.isKinematic = true;
            _items[_activeItemId].Transform.SetParent(_handPoint);
            _items[_activeItemId].Transform.DOMove(_handPoint.position, 0.1f);
            _items[_activeItemId].Transform.DOLocalRotate(Vector3.zero, 0.1f);

            item.OnTaked();
        }

        private int FindFreeSlot()
        {
            for (int i = 0; i < _items.Length; i++)
            {
                if (_items[i] == null)
                {
                    return i;
                }

            }

            return -1;
        }

        public void DropItem()
        {
            if (_items[_activeItemId] != null)
            {
                _items[_activeItemId].gameObject.SetActive(true);
                _items[_activeItemId].Rigidbody.isKinematic = false;
                _items[_activeItemId].Transform.SetParent(null);
                _items[_activeItemId].OnUnTaked();
                _items[_activeItemId] = null;
            }
        }

        private void Update(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Q) && _activeItemId != -1)
            {
                DropItem();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1)) SelectItem(0);
            else if (Input.GetKeyDown(KeyCode.Alpha2)) SelectItem(1);
            else if (Input.GetKeyDown(KeyCode.Alpha3)) SelectItem(2);
        }

        public void SelectItem(int id)
        {
            if (_itemsHolder.IsHolding) return;
            var oldItem = _activeItemId != -1 ? _items[_activeItemId] : null;
            if (id == -1)
            {
                oldItem?.gameObject.SetActive(false);
                oldItem?.OnUnTaked();
                _activeItemId = id;
                return;
            }

            if (id == _activeItemId)
            {
                SelectItem(-1);
                return;
            }

            oldItem?.gameObject.SetActive(false);
            _activeItemId = id;

            var newItem = _items[_activeItemId];
            newItem?.gameObject.SetActive(true);

            newItem?.OnTaked();
            oldItem?.OnUnTaked();
        }
    }
}
