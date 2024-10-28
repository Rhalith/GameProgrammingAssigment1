using UnityEngine;

namespace Scripts.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerControllerX : MonoBehaviour
    {
        [Header("Movement Variables")]
        [Tooltip("The maximum speed the player can move forward or backward \n Recommended value: 20")]
        [SerializeField] private float maxSpeed = 20f;
        [Tooltip("The rate at which the player accelerates or decelerates \n Recommended value: 15")]
        [SerializeField] private float acceleration = 15f;
        [Tooltip("The speed at which the player rotates when tilting \n Recommended value: 1.5")]
        [SerializeField] private float rotationSpeed = 1.5f;
    
        [Header("References")]
        [SerializeField] private Rigidbody rigidBody;
    
    
        private float _currentSpeed = 0f;
        private float _horizontalInput;
        private bool _isMovingForward = true;
    
        private bool _isEPressed;
        private bool _isFPressed;
        
        private bool _canMove = true;

        public bool CanMove
        {
            get => _canMove;
            set => _canMove = value;
        }

        private void Start()
        {
            if(rigidBody == null)
                rigidBody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if(!_canMove) return;
            _horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            
            if (verticalInput > 0)
            {
                _isMovingForward = true; // Move forward if pressed up
            }
            else if (verticalInput < 0)
            {
                _isMovingForward = false; // Move backward if pressed down
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                _isEPressed = true;
            }
            else if (Input.GetKeyUp(KeyCode.E))
            {
                _isEPressed = false;
            }
        
            if (Input.GetKeyDown(KeyCode.F))
            {
                _isFPressed = true;
            }
            else if (Input.GetKeyUp(KeyCode.F))
            {
                _isFPressed = false;
            }
        }

        private void FixedUpdate()
        {
            if (!_canMove)
            {
                _currentSpeed = 0f;
                rigidBody.velocity = Vector3.zero;
                rigidBody.angularVelocity = Vector3.zero;
                return;
            }
            
            float targetSpeed = _isMovingForward ? maxSpeed : -maxSpeed;
            
            _currentSpeed = Mathf.MoveTowards(_currentSpeed, targetSpeed, acceleration * Time.deltaTime);
            
            rigidBody.velocity = transform.forward * _currentSpeed + transform.right * (_horizontalInput * maxSpeed);
            
            if (_isEPressed)
            {
                rigidBody.angularVelocity = Vector3.right * -rotationSpeed;
            }
            else if (_isFPressed)
            {
                rigidBody.angularVelocity = Vector3.right * rotationSpeed;
            }
            else
            {
                rigidBody.angularVelocity = Vector3.zero;
            }
        }
    }
}