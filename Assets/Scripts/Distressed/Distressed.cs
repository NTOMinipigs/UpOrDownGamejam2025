using GameCore;
using UnityEngine;

namespace Distressed
{
    /// <summary>
    /// Фрукт которому нужно оказать помощь
    /// </summary>
    public class Distressed : MonoBehaviour
    {
        /// <summary>
        /// Главный объект префаба
        /// </summary>
        [SerializeField] private GameObject distressedObject;

        /// <summary>
        /// Флаг, указывающий на то, может ли объект быть подобран игроком 
        /// </summary>
        public bool canBePickedUp = false;
        
        void Update()
        {
            // Если чел нажимает Q и он может подобрать кента
            if (Input.GetKeyDown(KeyCode.Q) && canBePickedUp)
            {
                DistressedManager.Instance.AddDistressed();
                Destroy(distressedObject);
            }
        }
        
        /// <summary>
        /// Ставим статус того, что объект может быть подобран 
        /// </summary>
        /// <param name="other">Обязательный аргумент</param>
        private void OnTriggerEnter2D(Collider2D other)
        {
            // Добавляем кнопку
            KeysManager.Instance.AddKey(KeysManager.Keys.Q, "[Q] Подобрать пострадавшего");
            canBePickedUp = true;
        }

        /// <summary>
        /// Ставим статус того, что объект не может быть подобран
        /// </summary>
        /// <param name="other">Обязательный аргумент</param>
        private void OnTriggerExit2D(Collider2D other) 
        {
            KeysManager.Instance.RemoveKey(KeysManager.Keys.Q);
            canBePickedUp = false;
        }
    }
}