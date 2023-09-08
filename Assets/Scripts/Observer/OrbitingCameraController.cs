using UnityEngine;

namespace Observer
{
    public class OrbitingCameraController : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Camera camera;
    
        private Vector3 _previousPosition = Vector3.zero;
        private float _distance = -6;
        private float _minDistance = -3;
        private float _maxDistance = -10;
    
        private void Update()
        {
            RotateCamera();
        }

        void RotateCamera()
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                camera.transform.Translate(new Vector3(0, 0,  Input.GetAxis("Mouse ScrollWheel")));
                _distance += Input.GetAxis("Mouse ScrollWheel");
            }
        
            if (Input.GetMouseButtonDown(0))
            {
                _previousPosition = camera.ScreenToViewportPoint(Input.mousePosition);
            }

            if (!Input.GetMouseButton(0))
            {
                return;
            }
        
            var direction = _previousPosition - camera.ScreenToViewportPoint(Input.mousePosition);
            camera.transform.position = target.transform.position;
            camera.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);
            camera.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 180, Space.World);
            camera.transform.Translate(new Vector3(0, 0, _distance));
            _previousPosition = camera.ScreenToViewportPoint(Input.mousePosition);
        }
    }
}