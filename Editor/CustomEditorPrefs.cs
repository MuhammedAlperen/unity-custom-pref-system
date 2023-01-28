using PrefSystem.Runtime;
using UnityEditor;
using UnityEngine;

namespace PrefSystem.Editor
{
    [CreateAssetMenu(fileName = "EditorPrefs", menuName = "PrefSystem/EditorPrefs")]
    public class CustomEditorPrefs : CustomPrefManager
    {
        private const string PrefAssetPath = "Assets/Resources/Prefs/EditorPrefs.asset";

        public static IPrefManager Instance => _instance ??= GetPrefAsset();
        private static IPrefManager _instance;

        private static CustomEditorPrefs GetPrefAsset()
        {
            var asset = AssetDatabase.LoadAssetAtPath<CustomEditorPrefs>(PrefAssetPath);
            if (asset != null) return asset;
            
            asset = CreateInstance<CustomEditorPrefs>();
            AssetDatabase.CreateAsset(asset, PrefAssetPath);
            AssetDatabase.SaveAssets();

            return asset;
        }
    }
}