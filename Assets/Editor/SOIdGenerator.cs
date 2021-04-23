using UnityEditor;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class SOIdGenerator : EditorWindow {

    [MenuItem("BattleSystem/SOIdGenerator")]
    private static void ShowWindow() {
        var window = GetWindow<SOIdGenerator>();
        window.titleContent = new GUIContent("SOIdGenerator");
        window.Show();
    }

    private void OnGUI() {
        GUILayout.Label("Create a new Id for units");
        if(GUILayout.Button("Create")) {
            string[] guids = AssetDatabase.FindAssets("t:UnitSO", null);
            string[] paths = guids.ToList().Select(it => AssetDatabase.GUIDToAssetPath(it)).ToArray();
            List<UnitSO> units = paths.ToList().Select(it => AssetDatabase.LoadAssetAtPath<UnitSO>(it)).ToList();
            units.ForEach(it => it.unitId = it.unitName + Random.Range(10000, 99999));
            // UnitSO[] units = ScriptableObject.FindObjectsOfType<UnitSO>();
            // units.ToList().ForEach(it => it.unitId = it.unitName + Random.Range(10000, 99999));
        }
    }
}