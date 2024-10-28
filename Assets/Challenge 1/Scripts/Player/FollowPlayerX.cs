using UnityEngine;

namespace Scripts.Player
{
    public class FollowPlayerX : MonoBehaviour
    {
        [SerializeField] private GameObject plane;
        [SerializeField] private Vector3 sideViewOffset;
        [SerializeField] private Vector3 backViewOffset;
        private bool _isBackView;

        public float rotationSpeed = 5.0f;

        private void Update()
        {
            // Check if the "B" key is pressed to toggle between side and back view
            if (Input.GetKeyDown(KeyCode.B))
            {
                _isBackView = !_isBackView;
            }
        }

        private void FixedUpdate()
        {

            // Set the current offset based on the view mode (side or back view)
            Vector3 currentOffset = _isBackView ? backViewOffset : sideViewOffset;

            // Make the camera follow the plane's position
            transform.position = plane.transform.position + plane.transform.rotation * currentOffset;
            
            if (_isBackView)
            {
                RotateWithPlane();
            }
            else
            {
                transform.LookAt(plane.transform);
            }
        }

        private void RotateWithPlane()
        {
            Quaternion targetRotation = plane.transform.rotation;
            
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}