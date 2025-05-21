using UnityEngine;

namespace Common
{
	public class Updater : MonoBehaviour
	{
		public event System.Action<float> Updated;

        private void Update()
        {
            Updated?.Invoke(Time.deltaTime);
        }

        private void OnDisable()
        {
            Updated = null;
        }
    }
}