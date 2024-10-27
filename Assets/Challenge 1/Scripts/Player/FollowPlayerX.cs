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

            // If the camera is in back view, ensure it rotates to always face the back of the plane
            if (_isBackView)
            {
                RotateWithPlane();
            }
            else
            {
                // For side view, ensure the camera stays in a static side orientation
                transform.LookAt(plane.transform);
            }
        }

        private void RotateWithPlane()
        {
            // Calculate the target rotation based on the plane's full orientation
            Quaternion targetRotation = plane.transform.rotation;

            // Smoothly rotate the camera towards the target rotation to match the plane's rear view
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}