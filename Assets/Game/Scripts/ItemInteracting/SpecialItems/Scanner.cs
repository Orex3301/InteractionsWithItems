using Data;
using Inventory;
using System.Collections;
using TMPro;
using UnityEngine;

namespace ItemInteracting
{
    public class Scanner : SmallItem
    {
        [SerializeField] private float rayDistance = 5f;
        [SerializeField] private TMP_Text _nameText;

        private bool _canUse = false;

        private void Start()
        {
            _nameText.text = string.Empty;
        }

        public override void OnTaked()
        {
            _canUse = true;
        }

        public override void OnUnTaked()
        {
            _canUse = false;
        }

        private void Update()
        {
            if (_canUse)
            {
                Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
                RaycastHit hit;
                IScannable scannableItem = null;

                if (Physics.Raycast(ray, out hit, rayDistance))
                {
                    scannableItem = hit.collider.GetComponent<IScannable>();
                }

                if (Input.GetKeyDown(KeyCode.C))
                {
                    if (scannableItem != null)
                    {
                        _nameText.text = scannableItem.Name;
                        StopAllCoroutines();
                        StartCoroutine(WaitingCoroutine());
                    }
                }
            }
        }

        private IEnumerator WaitingCoroutine()
        {
            yield return new WaitForSeconds(2f);
            _nameText.text = string.Empty;
        }
    }
}
