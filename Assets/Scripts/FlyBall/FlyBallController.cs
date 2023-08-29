using MovePath;
using UnityEngine;

namespace FlyBall
{
    public class FlyBallController : MonoBehaviour
    {
        [SerializeField] private MovePathController movePathController;
        [SerializeField] private float moveSpeed;

        private readonly float _minDistance = 0.2f;
        
        private int _lastPointIndex;
        private int _newPointIndex;
        private bool _initialized;
        
        private void Start()
        {
            if (!movePathController || movePathController.MovePoints.Count == 0)
            {
                Debug.LogWarningFormat("[{0}][Start]movePathController has a problem!", GetType().Name);
                return;
            }

            _lastPointIndex = 0;
            _newPointIndex = 1;
            
            if (movePathController.MovePoints.Count == 1)
            {
                _newPointIndex = 0;
            }

            transform.position = movePathController.MovePoints[_lastPointIndex];
            _initialized = true;
        }

        private void Update()
        {
            if (!_initialized)
            {
                return;
            }

            Move();
        }

        private void Move()
        {
            if (Vector3.Distance(transform.position, movePathController.MovePoints[_newPointIndex]) > _minDistance)
            {
                var step = moveSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, movePathController.MovePoints[_newPointIndex], step);
                return;
            }

            _lastPointIndex++;

            if (_lastPointIndex == movePathController.MovePoints.Count)
            {
                _lastPointIndex = 0;
            }

            _newPointIndex = _lastPointIndex + 1;

            if (_newPointIndex == movePathController.MovePoints.Count)
            {
                _newPointIndex = 0;
            }
        }
    }
}