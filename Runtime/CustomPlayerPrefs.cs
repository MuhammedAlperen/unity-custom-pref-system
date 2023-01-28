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
            return Resources.Load<CustomPlayerPrefs>("Prefs/PlayerPrefs");
        }
    }
}