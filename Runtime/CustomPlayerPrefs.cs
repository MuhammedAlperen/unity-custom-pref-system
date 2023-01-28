using UnityEngine;

namespace PrefSystem.Runtime
{
    [CreateAssetMenu(fileName = "PlayerPrefs", menuName = "PrefSystem/PlayerPrefs")]
    public class CustomPlayerPrefs : CustomPrefManager
    {
        public static IPrefManager Instance => _instance ??= GetPrefAsset();
        private static IPrefManager _instance;

        private static IPrefManager GetPrefAsset()
        {
            // CustomPlayerPrefs works with ScriptableObjects, so the data won't be saved in the build.
            // For Debugging we can still use CustomPlayerPrefs, but for build we need to use UnityPlayerPrefs.
#if UNITY_EDITOR
            return UnityEditor.AssetDatabase.LoadAssetAtPath<CustomPlayerPrefs>("Assets/ScriptableObjects/Editor/Prefs/PlayerPrefs.asset");
#else
            return UnityPlayerPrefs.Instance;
#endif
        }
    }
}