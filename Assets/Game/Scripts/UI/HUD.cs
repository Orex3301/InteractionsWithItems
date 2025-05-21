using UnityEngine;

namespace UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] GameObject _menu;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _menu.SetActive(!_menu.activeSelf);
                Time.timeScale = _menu.activeSelf ? 0 : 1;
            }
        }
    }
}
