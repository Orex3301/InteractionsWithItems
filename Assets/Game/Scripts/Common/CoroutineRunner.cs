using UnityEngine;

namespace Common
{
    public class CoroutineRunner : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}
