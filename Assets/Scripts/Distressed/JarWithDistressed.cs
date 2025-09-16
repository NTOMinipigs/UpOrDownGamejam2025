using GameCore;
using UnityEngine;


namespace Distressed
{
    /// <summary>
    /// Банка с утопающим (или тараканом)
    /// </summary>
    public class JarWithDistressed : MonoBehaviour
    {
        /// <summary>
        /// То, что выпадет с банки
        /// </summary>
        [SerializeField] private GameObject ItemPrefab;

        /// <summary>
        /// Может ли банка быть открытой сейчас?
        /// </summary>
        private bool _canBeOpened = false;

        void Update()
        {
            if (_canBeOpened && Input.GetKeyDown(KeyCode.E)) OpenJar();
        }
        
        /// <summary>
        /// Разрешить открыть банку
        /// </summary>
        /// <param name="other">Обязательный параметр</param>
        void OnTriggerEnter2D(Collider2D other)
        {
            _canBeOpened = true;
            KeysManager.Instance.AddKey(KeysManager.Keys.E, "[E] Открыть банку");
        }

        /// <summary>
        /// Запретить открывать банку
        /// </summary>
        /// <param name="other">Коллайдер</param>
        void OnTriggerExit2D(Collider2D other)
        {
            _canBeOpened = false;
            KeysManager.Instance.RemoveKey(KeysManager.Keys.E);
        }
        
        /// <summary>
        /// Открой банку
        /// </summary>
        void OpenJar()
        {
            // Создаем объект
            Instantiate(ItemPrefab, transform.position, Quaternion.identity);
            
            // Уничтожаем банку
            Destroy(gameObject);
        }
        
    }
}