using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemManager))]
public class ItemManagerEditor : Editor
{
    private SerializedProperty itemsList;

    private ItemType itemToAdd;

    private void OnEnable()
    {
        itemsList = serializedObject.FindProperty("items");
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        serializedObject.Update();

        EditorGUILayout.Space();

        // select the item type to add later
        itemToAdd = (ItemType)EditorGUILayout.EnumPopup("Item Type", itemToAdd);
        if (GUILayout.Button("Add New Item"))
        {
            Item newItem = new Item(itemToAdd);
            (target as ItemManager).AddItem(newItem);
            EditorUtility.SetDirty(target);
        }

        EditorGUILayout.Space();

        for (int i = 0; i < itemsList.arraySize; i++)
        {
            SerializedProperty itemProperty = itemsList.GetArrayElementAtIndex(i);
            SerializedProperty itemTypeProperty = itemProperty.FindPropertyRelative("Type");

            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.PropertyField(itemTypeProperty, GUIContent.none);

            EditorGUILayout.EndHorizontal();
        }

        serializedObject.ApplyModifiedProperties();
    }
}
