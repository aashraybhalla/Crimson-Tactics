using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ObstacleData))]
public class ObstacleToolEditor : Editor
{
	private SerializedProperty obstacleDataProperty;

	void OnEnable()
	{
		obstacleDataProperty = serializedObject.FindProperty("obstacleData");
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();
		EditorGUILayout.PropertyField(obstacleDataProperty, new GUIContent("Obstacle Grid"), true);
		serializedObject.ApplyModifiedProperties();
	}
}