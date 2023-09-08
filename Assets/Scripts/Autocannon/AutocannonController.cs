using UnityEngine;

namespace Autocannon
{
    public class AutocannonController : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Transform bottomParts;
        [SerializeField] private Transform topParts;

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
            
            if (!bottomParts)
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
            bottomParts.LookAt(target);
            var eulerAnglesAllParts = bottomParts.rotation.eulerAngles;
            eulerAnglesAllParts.x = 0;
            eulerAnglesAllParts.z = 0;
            bottomParts.rotation = Quaternion.Euler(eulerAnglesAllParts);
            
            topParts.LookAt(target);
            var eulerAnglesTopParts = topParts.rotation.eulerAngles;
            eulerAnglesAllParts.y = 0;
            eulerAnglesAllParts.z = 0;
            topParts.rotation = Quaternion.Euler(eulerAnglesTopParts);
        }
    }
}