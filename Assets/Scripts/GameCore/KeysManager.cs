using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GameCore
{
    /// <summary>
    /// Менеджер кнопок
    /// </summary>
    public class KeysManager : MonoBehaviour
    {
        
        #region UI elements

        /// <summary>
        /// Transform объекта с компонентом VerticalLayoutGroup в котором должны лежать клавиши
        /// </summary>
        [SerializeField] private Transform _keysParent;
        
        /// <summary>
        /// Префаб элемента, который добавляется в _keysParent
        /// </summary>
        [SerializeField] private GameObject _keyPrefab;

        #endregion
        
        
        /// <summary>
        /// Возможные клавиши
        /// </summary>
        public enum Keys
        {
            AD,
            Space
        }

        /// <summary>
        /// KeysManager is Singleton
        /// </summary>
        public static KeysManager Instance { private set; get; }
        
        /// <summary>
        /// Словарь хранящий пару клавиша - объект пояснение
        /// </summary>
        private Dictionary<Keys, GameObject> _keysGameObjects = new();


        void Start()
        {
            Instance = this;
        }

        /// <summary>
        /// Добавьте в список элементов пояснение для новой клавиши
        /// </summary>
        /// <param name="key">Код клавиши</param>
        /// <param name="text">Пояснение для клавиши</param>
        public void AddKey(Keys key, string text)
        {
            if (_keysGameObjects.ContainsKey(key)) _keysGameObjects[key].SetActive(true);
            else _keysGameObjects[key] = CreateNewKey(text);
        }
        
        /// <summary>
        /// Удалить клавишу
        /// </summary>
        /// <param name="key">Код клавиши</param>
        public void RemoveKey(Keys key)
        {
            _keysGameObjects[key].SetActive(false);   
        }

        /// <summary>
        /// Создать новый префаб клавиши
        /// </summary>
        /// <param name="text">Текст который нужно вывести</param>
        /// <returns></returns>
        private GameObject CreateNewKey(string text)
        {
            GameObject newKeyGameObject = Instantiate(_keyPrefab, _keysParent);
            newKeyGameObject.GetComponent<TextMeshProUGUI>().text = text;
            return newKeyGameObject;
        }
        
    }
}