using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace PrefSystem.Runtime
{
    public abstract class CustomPrefManager : ScriptableObject, IPrefManager
    {
        [SerializeField] private List<PrefData> m_prefData = new List<PrefData>();

        public string GetString(string key, string defaultValue = "")
        {
            var prefData = m_prefData.Find(x => x.Key == key);
            if (prefData != null) return prefData.StringValue;
            
            prefData = new PrefData(key) { StringValue = defaultValue };
            m_prefData.Add(prefData);
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
            return prefData.StringValue;
        }
        
        public void SetString(string key, string value)
        {
            var prefData = m_prefData.Find(x => x.Key == key);
            if (prefData == null)
            {
                prefData = new PrefData(key);
                m_prefData.Add(prefData);
            }
            prefData.StringValue = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
        
        public int GetInt(string key, int defaultValue = 0)
        {
            var prefData = m_prefData.Find(x => x.Key == key);
            if (prefData != null) return prefData.IntValue;
            
            prefData = new PrefData(key) { IntValue = defaultValue };
            m_prefData.Add(prefData);
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif

            return prefData.IntValue;
        }
        
        public void SetInt(string key, int value)
        {
            var prefData = m_prefData.Find(x => x.Key == key);
            if (prefData == null)
            {
                prefData = new PrefData(key);
                m_prefData.Add(prefData);
            }
            prefData.IntValue = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
        
        public float GetFloat(string key, float defaultValue = 0f)
        {
            var prefData = m_prefData.Find(x => x.Key == key);
            if (prefData != null) return prefData.FloatValue;
            
            prefData = new PrefData(key) { FloatValue = defaultValue };
            m_prefData.Add(prefData);
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif

            return prefData.FloatValue;
        }
        
        public void SetFloat(string key, float value)
        {
            var prefData = m_prefData.Find(x => x.Key == key);
            if (prefData == null)
            {
                prefData = new PrefData(key);
                m_prefData.Add(prefData);
            }
            prefData.FloatValue = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }

        [Serializable]
        private class PrefData
        {
            [SerializeField] private string m_key;

            [SerializeField] private int m_intValue;
            [SerializeField] private float m_floatValue;
            [SerializeField] private string m_stringValue;

            public string Key => m_key;

            public int IntValue
            {
                get => m_intValue;
                set => m_intValue = value;
            }

            public float FloatValue
            {
                get => m_floatValue;
                set => m_floatValue = value;
            }

            public string StringValue
            {
                get => m_stringValue;
                set => m_stringValue = value;
            }

            public PrefData(string key)
            {
                m_key = key;
            }
        }
    }
}