using UnityEngine;

namespace Scripts.Plane
{
    public class PropellerController : MonoBehaviour
    {
        [SerializeField] private float spinSpeed = 1000f;
        
        private void Update()
        {
            transform.Rotate(Vector3.forward * (spinSpeed * Time.deltaTime));
        }
    }
}