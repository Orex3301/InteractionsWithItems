using UnityEngine;
using DG.Tweening;

namespace Player
{
	public class CameraHolder : MonoBehaviour
	{
		[SerializeField] private Transform _normalCameraPoint;
		[SerializeField] private Transform _sitCameraPoint;
		[SerializeField] private Transform _cameraPoint;
		[SerializeField] private Camera _camera;

		private Transform _currentCameraPoint;

		private void Start()
		{
			_currentCameraPoint = _normalCameraPoint;
			_cameraPoint.position = _normalCameraPoint.position;
		}

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
			{
				if (_currentCameraPoint == _normalCameraPoint)
				{
					_currentCameraPoint = _sitCameraPoint;
				}
				else _currentCameraPoint = _normalCameraPoint;

				_cameraPoint.DOMove(_currentCameraPoint.position, 0.1f);
			}
			if (Input.GetKey(KeyCode.V))
			{
				if (_camera.fieldOfView != 40)
					_camera.fieldOfView = 40;
			}
			else
			{
                if (_camera.fieldOfView != 90)
                    _camera.fieldOfView = 90;
            }
        }
    }
}