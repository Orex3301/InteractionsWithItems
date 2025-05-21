using Data.Player;
using UnityEngine;
namespace Player
{
    public class MovementHandler : MonoBehaviour
    {
        private Transform _transform;
        private Camera _camera;
        private float _moveSpeed;
        private float _rotationSpeed;
        private float _rotationX;
        private float _lookXLimit;
        private bool _isWalking;
        private float _originalYPosition;
        private float _cameraShakeSpeed;
        private float _cameraShakeHeight;
        private float _targetYPosition;
        public float _jumpForce; // Сила прыжка
        private Rigidbody _rigidbody;
        private bool _isGrounded;

        public void Initialize(PlayerConfig playerConfig, Camera camera)
        {
            _transform = GetComponent<Transform>();
            _rigidbody = GetComponent<Rigidbody>();
            _camera = camera;
            _moveSpeed = playerConfig.MovingSpeed;
            _rotationSpeed = playerConfig.RotationSpeed;
            _lookXLimit = playerConfig.LookXLimit;
            _originalYPosition = _camera.transform.localPosition.y;
            _cameraShakeHeight = playerConfig.CameraShakeHeight;
            _cameraShakeSpeed = playerConfig.CameraShakeSpeed;
            _targetYPosition = _originalYPosition;
            _jumpForce = playerConfig.JumpForce;
        }


        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            Move();
            LookAround();
            CameraShake();
            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            {
                Jump();
            }
        }

        private void Move()
        {
            float moveHorizontal = Input.GetAxis("Horizontal") * _moveSpeed * Time.deltaTime;
            float moveVertical = Input.GetAxis("Vertical") * _moveSpeed * Time.deltaTime;

            Vector3 movement = _transform.right * moveHorizontal + _transform.forward * moveVertical;
            _transform.position += movement;

            _isWalking = movement != Vector3.zero;
        }

        private void LookAround()
        {
            float rotationY = Input.GetAxis("Mouse X") * _rotationSpeed * Time.deltaTime;
            _rotationX -= Input.GetAxis("Mouse Y") * _rotationSpeed * Time.deltaTime;
            _rotationX = Mathf.Clamp(_rotationX, -_lookXLimit, _lookXLimit);

            _transform.Rotate(0, rotationY, 0);
            _camera.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
        }

        private void CameraShake()
        {
            if (_isWalking)
            {
                _targetYPosition = _originalYPosition + Mathf.Sin(Time.time * _cameraShakeSpeed) * _cameraShakeHeight;
            }
            else
            {
                _targetYPosition = Mathf.Lerp(_camera.transform.localPosition.y, _originalYPosition, _cameraShakeSpeed * Time.deltaTime);
            }

            _camera.transform.localPosition = new Vector3(_camera.transform.localPosition.x, _targetYPosition, _camera.transform.localPosition.z);
        }

        

        private void Jump()
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isGrounded = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _isGrounded = true;
            }
        }
    }
}