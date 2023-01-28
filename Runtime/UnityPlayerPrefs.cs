using UnityEngine;

namespace PrefSystem.Runtime
{
    public class UnityPlayerPrefs : IPrefManager
    {
        public static IPrefManager Instance => _instance ??= new UnityPlayerPrefs();
        private static IPrefManager _instance;

        public string GetString(string key, string defaultValue = null) => PlayerPrefs.GetString(key, defaultValue);
        public void SetString(string key, string value) => PlayerPrefs.SetString(key, value);
        public int GetInt(string key, int defaultValue = 0) => PlayerPrefs.GetInt(key, defaultValue);
        public void SetInt(string key, int value) => PlayerPrefs.SetInt(key, value);
        public float GetFloat(string key, float defaultValue = 0) => PlayerPrefs.GetFloat(key, defaultValue);
        public void SetFloat(string key, float value) => PlayerPrefs.SetFloat(key, value);
    }
}