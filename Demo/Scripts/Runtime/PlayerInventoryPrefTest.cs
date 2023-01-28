using System;
using PrefSystem.Runtime;
using UnityEngine;

namespace PrefSystem.Demo.Scripts.Runtime
{
    public class PlayerInventoryPrefTest : MonoBehaviour
    {
        [SerializeField] private Inventory m_playerInventory;

        // Needs to be injected. For demo purposes i'm using a custom inspector.
        private IPrefManager _prefManager;

        public void SaveItemsToPrefs()
        {
            var inventoryJson = JsonUtility.ToJson(m_playerInventory, true);
            _prefManager.SetString("Items", inventoryJson);
        }

        public void LoadItemsFromPrefs()
        {
            var inventoryJson = _prefManager.GetString("Items");
            m_playerInventory = JsonUtility.FromJson<Inventory>(inventoryJson);
        }
    }

    [Serializable]
    public class Inventory
    {
        [SerializeField] private Item[] m_items;
    }

    [Serializable]
    public class Item
    {
        public string Name;
        public int Count;
    }
}
