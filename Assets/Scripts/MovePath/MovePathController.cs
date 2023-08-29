using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MovePath
{
    public class MovePathController : MonoBehaviour
    {
        public List<Vector3> MovePoints 
        {
            get
            {
                var positions = new List<Vector3>();
                
                foreach (var point in _movePoints)
                {
                    positions.Add(point.transform.position);
                }

                return positions;
            }
        }
        
        [SerializeField] private List<GameObject> _movePoints = new List<GameObject>();

        public void AddNewPoint()
        {
            _movePoints.Add(new GameObject($"PathPoint_{_movePoints.Count}"));
            _movePoints[^1].transform.SetParent(transform);
            _movePoints[^1].transform.localPosition = Vector3.zero;
            _movePoints[^1].AddComponent<PointController>();
            PrefabUtility.ApplyPrefabInstance(gameObject, InteractionMode.AutomatedAction);
        }

        public void RemoveAt(int index)
        {
            DestroyImmediate(_movePoints[index]);
            _movePoints.RemoveAt(index);
            PrefabUtility.ApplyPrefabInstance(gameObject, InteractionMode.AutomatedAction);
        }

        public void SetPosition(int index, Vector3 newPosition)
        {
            if (index < 0 || index >= _movePoints.Count)
            {
                Debug.LogWarningFormat("[{0}][SetPosition]Wrong index: {1}", GetType().Name, index);
                return;
            }
            
            _movePoints[index].transform.position = newPosition;
            PrefabUtility.ApplyPrefabInstance(gameObject, InteractionMode.AutomatedAction);
        }
        
        private void OnDrawGizmos()
        {
            for (var i = 1; i < _movePoints.Count; i++)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine (_movePoints[i].transform.position, _movePoints[i-1].transform.position);

                if (i == _movePoints.Count - 1)
                {
                    Gizmos.DrawLine (_movePoints[i].transform.position, _movePoints[0].transform.position);
                }
            }
        }
    }
}