using UnityEngine;

namespace MovePath
{
    public class PointController : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Gizmos.DrawIcon(transform.position, "point.png", true);
        }
    }
}