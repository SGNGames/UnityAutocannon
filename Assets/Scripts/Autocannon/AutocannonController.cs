using UnityEngine;

namespace Autocannon
{
    public class AutocannonController : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Transform allParts;
        [SerializeField] private Transform topParts;

        [SerializeField]private float speed;

        private bool _initialized;

        private void Start()
        {
            if (CheckingError())
            {
                return;
            }

            _initialized = true;
        }

        private bool CheckingError()
        {
            if (!target)
            {
                Debug.LogWarningFormat("[{0}][CheckingError]target is empty!", GetType().Name);
                return true;
            }
            
            if (!allParts)
            {
                Debug.LogWarningFormat("[{0}][CheckingError]allParts is empty!", GetType().Name);
                return true;
            }
            
            if (!topParts)
            {
                Debug.LogWarningFormat("[{0}][CheckingError]topParts is empty!", GetType().Name);
                return true;
            }

            return false;
        }

        private void Update()
        {
            if (!_initialized)
            {
                return;
            }

            Rotation();
        }

        private void Rotation()
        {
            allParts.LookAt(target);
            var eulerAnglesAllParts = allParts.rotation.eulerAngles;
            eulerAnglesAllParts.x = 0;
            eulerAnglesAllParts.z = 0;
            allParts.rotation = Quaternion.Euler(eulerAnglesAllParts);
            
            topParts.LookAt(target);
            var eulerAnglesTopParts = topParts.rotation.eulerAngles;
            eulerAnglesAllParts.y = 0;
            eulerAnglesAllParts.z = 0;
            topParts.rotation = Quaternion.Euler(eulerAnglesTopParts);
        }
    }
}
