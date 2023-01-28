namespace PrefSystem.Runtime
{
    public interface IPrefManager
    {
        string GetString(string key, string defaultValue = null);
        void SetString(string key, string value);
        int GetInt(string key, int defaultValue = 0);
        void SetInt(string key, int value);
        float GetFloat(string key, float defaultValue = 0f);
        void SetFloat(string key, float value);
    }
}