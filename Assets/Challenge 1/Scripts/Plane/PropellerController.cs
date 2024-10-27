using UnityEngine;

namespace Scripts.Plane
{
    public class PropellerController : MonoBehaviour
    {
        [SerializeField] private float spinSpeed = 1000f;

        // Update is called once per frame
        private void Update()
        {
            transform.Rotate(Vector3.forward * (spinSpeed * Time.deltaTime));
        }
    }
}