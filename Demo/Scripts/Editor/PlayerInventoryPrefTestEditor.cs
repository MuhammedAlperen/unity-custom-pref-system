using System.Reflection;
using PrefSystem.Demo.Scripts.Runtime;
using PrefSystem.Runtime;
using UnityEditor;
using UnityEngine;

namespace PrefSystem.Demo.Scripts.Editor
{
    [CustomEditor(typeof(PlayerInventoryPrefTest))]
    public class PlayerInventoryPrefTestEditor : UnityEditor.Editor
    {
        private SerializedProperty _inventoryProperty;

        private FieldInfo _prefManagerField;
        private PrefManagerType _prefManagerType;

        private void OnEnable()
        {
            _inventoryProperty = serializedObject.FindProperty("m_playerInventory");
            _prefManagerField = typeof(PlayerInventoryPrefTest).GetField("_prefManager", BindingFlags.NonPublic | BindingFlags.Instance);
        }

        public override void OnInspectorGUI()
        {
            var testTarget = (PlayerInventoryPrefTest) target;

            _prefManagerType = GetPrefManagerType(testTarget);

            serializedObject.Update();

            EditorGUILayout.PropertyField(_inventoryProperty);
            DrawPrefManagerSelectionButtons(testTarget);
            DrawSaveLoadInventoryButtons(testTarget);

            serializedObject.ApplyModifiedProperties();
        }

        private void DrawPrefManagerSelectionButtons(PlayerInventoryPrefTest testTarget)
        {
            GUILayout.BeginHorizontal();
            EditorGUI.BeginDisabledGroup(_prefManagerType == PrefManagerType.CustomPlayerPrefs);
            if (GUILayout.Button("Use CustomPlayerPrefs"))
            {
                // Set targets _prefManager field to CustomPlayerPrefs through reflection
                _prefManagerField.SetValue(testTarget, CustomPlayerPrefs.Instance);
                Debug.Log("PrefManager has successfully been set to <b>CustomPlayerPrefs</b>", testTarget);
            }

            EditorGUI.EndDisabledGroup();

            EditorGUI.BeginDisabledGroup(_prefManagerType == PrefManagerType.UnityPlayerPrefs);
            if (GUILayout.Button("Use UnityPlayerPrefs"))
            {
                // Set targets _prefManager field to UnityPlayerPrefs through reflection
                _prefManagerField.SetValue(testTarget, UnityPlayerPrefs.Instance);
                Debug.Log("PrefManager has successfully been set to <b>UnityPlayerPrefs</b>", testTarget);
            }

            EditorGUI.EndDisabledGroup();
            GUILayout.EndHorizontal();
        }

        private void DrawSaveLoadInventoryButtons(PlayerInventoryPrefTest testTarget)
        {
            EditorGUI.BeginDisabledGroup(_prefManagerType == PrefManagerType.None);
            if (GUILayout.Button("Save Items To Prefs"))
            {
                testTarget.SaveItemsToPrefs();
                Debug.Log(_prefManagerType == PrefManagerType.CustomPlayerPrefs
                    ? "Items have successfully been saved to <b>CustomPlayerPrefs</b>. Check the file at Assets/Resources/Prefs/CustomPlayerPrefs"
                    : "Items have successfully been saved to <b>UnityPlayerPrefs</b>.", testTarget);
            }

            if (GUILayout.Button("Load Items From Prefs"))
            {
                testTarget.LoadItemsFromPrefs();
                Debug.Log(_prefManagerType == PrefManagerType.CustomPlayerPrefs
                    ? "Items have successfully been loaded from <b>CustomPlayerPrefs</b>. Check the playerInventory field."
                    : "Items have successfully been loaded from <b>UnityPlayerPrefs</b>.", testTarget);
            }

            EditorGUI.EndDisabledGroup();
        }

        private PrefManagerType GetPrefManagerType(PlayerInventoryPrefTest testTarget)
        {
            // Get the type of the assigned PrefManager through reflection
            var prefManager = _prefManagerField.GetValue(testTarget);
            
            if (prefManager == null) return PrefManagerType.None;
            
            return prefManager.GetType() == typeof(CustomPlayerPrefs)
                ? PrefManagerType.CustomPlayerPrefs
                : PrefManagerType.UnityPlayerPrefs;
        }

        private enum PrefManagerType
        {
            None,
            UnityPlayerPrefs,
            CustomPlayerPrefs,
        }
    }
}