using UnityEngine;

namespace Scripts.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerControllerX : MonoBehaviour
    {
        [Header("Movement Variables")]
        [Tooltip("The maximum speed the player can move forward or backward \n Recommended value: 20")]
        [SerializeField] private float maxSpeed = 20f;
        [Tooltip("The rate at which the player accelerates or decelerates \n Recommended value: 5")]
        [SerializeField] private float acceleration = 5f;
        [Tooltip("The speed at which the player rotates when tilting \n Recommended value: 2")]
        [SerializeField] private float rotationSpeed = 2f;
    
        [Header("References")]
        [SerializeField] private Rigidbody rigidBody;
    
    
        private float _currentSpeed = 0f;
        private float _horizontalInput;
        private bool _isMovingForward = true;
    
        private bool _isEPressed;
        private bool _isFPressed;
        
        private bool _canMove = true;

        private void Start()
        {
            // Check if the Rigidbody component is assigned in the Inspector
            if(rigidBody == null)
                rigidBody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if(!_canMove) return;
            // Get the user's horizontal input for left/right movement
            _horizontalInput = Input.GetAxis("Horizontal");

            // Get the user's vertical input for changing direction
            float verticalInput = Input.GetAxis("Vertical");

            // Update the movement direction based on vertical input
            if (verticalInput > 0)
            {
                _isMovingForward = true; // Move forward if pressing up
            }
            else if (verticalInput < 0)
            {
                _isMovingForward = false; // Move backward if pressing down
            }
        
            // Check if the tilt keys (E and F) are pressed
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
            if(!_canMove) return;
            // Determine the target speed based on the movement direction
            float targetSpeed = _isMovingForward ? maxSpeed : -maxSpeed;

            // Smoothly accelerate or decelerate to the target speed
            _currentSpeed = Mathf.MoveTowards(_currentSpeed, targetSpeed, acceleration * Time.deltaTime);

            // Set the forward/backward velocity
            rigidBody.velocity = transform.forward * _currentSpeed + transform.right * (_horizontalInput * maxSpeed);

            // Apply tilt rotation using angular velocity only when pressing E or F
            if (_isEPressed)
            {
                rigidBody.angularVelocity = Vector3.right * -rotationSpeed; // Tilt up (E key)
            }
            else if (_isFPressed)
            {
                rigidBody.angularVelocity = Vector3.right * rotationSpeed; // Tilt down (F key)
            }
            else
            {
                // Reset angular velocity when no tilt input is pressed
                rigidBody.angularVelocity = Vector3.zero;
            }
        }
        
        public void StopMovement()
        {
            _canMove = false;
            _currentSpeed = 0f;
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
        }
    }
}