using PrefSystem.Runtime;
using UnityEditor;

namespace PrefSystem.Editor
{
    public class UnityEditorPrefs : IPrefManager
    {
        public static IPrefManager Instance => _instance ??= new UnityEditorPrefs();
        private static IPrefManager _instance;

        public string GetString(string key, string defaultValue = null) => EditorPrefs.GetString(key, defaultValue);
        public void SetString(string key, string value) => EditorPrefs.SetString(key, value);
        public int GetInt(string key, int defaultValue = 0) => EditorPrefs.GetInt(key, defaultValue);
        public void SetInt(string key, int value) => EditorPrefs.SetInt(key, value);
        public float GetFloat(string key, float defaultValue = 0) => EditorPrefs.GetFloat(key, defaultValue);
        public void SetFloat(string key, float value) => EditorPrefs.SetFloat(key, value);
    }
}