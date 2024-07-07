using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(BoolArray2D))]
public class GUIPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Get the properties of the BoolArray2D
        SerializedProperty rows = property.FindPropertyRelative("rows");
        SerializedProperty columns = property.FindPropertyRelative("columns");
        SerializedProperty array = property.FindPropertyRelative("array");

        int gridSize = columns.intValue;
        float buttonSize = 20f;
        float labelWidth = 20f;

        // Display the label for the entire grid
        position = EditorGUI.PrefixLabel(position, label);

        // Adjust position to start drawing the grid
        position.y += EditorGUIUtility.singleLineHeight;
        position.height = buttonSize;

        for (int y = 0; y < gridSize; y++)
        {
            position.x = labelWidth;
            EditorGUILayout.BeginHorizontal();
            for (int x = 0; x < gridSize; x++)
            {
                int index = x + y * gridSize;
                bool value = array.GetArrayElementAtIndex(index).boolValue;
                bool newValue = EditorGUI.Toggle(new Rect(position.x, position.y, buttonSize, buttonSize), GUIContent.none, value);
                if (newValue != value)
                {
                    array.GetArrayElementAtIndex(index).boolValue = newValue;
                }
                position.x += buttonSize;
            }
            EditorGUILayout.EndHorizontal();
            position.y += buttonSize;
        }

        // Make sure to apply any changes to the serialized object
        property.serializedObject.ApplyModifiedProperties();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        int gridSize = property.FindPropertyRelative("columns").intValue;
        return (gridSize * 20f) + EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
    }
}
