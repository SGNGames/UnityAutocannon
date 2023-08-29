using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MovePath.Editor
{
    [CustomEditor(typeof(MovePathController))]
    public class MovePathControllerEditor : UnityEditor.Editor
    {
        private List<Vector3> _movePoints;
        
        public override void OnInspectorGUI() 
        {
            serializedObject.Update();
            
            if (target is MovePathController movePathController)
            {
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Add Point"))
                {
                    movePathController.AddNewPoint();
                }
                GUILayout.EndHorizontal();

                _movePoints = movePathController.MovePoints;
                
                for (var i = 0; i < _movePoints.Count; i++)
                {
                    GUILayout.BeginHorizontal();
                    _movePoints[i] = EditorGUILayout.Vector3Field($"Path Point {i}:", _movePoints[i]);
                    movePathController.SetPosition(i, _movePoints[i]);

                    if (GUILayout.Button("X"))
                    {
                        movePathController.RemoveAt(i);
                    }
                    GUILayout.EndHorizontal();
                }
            }
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}