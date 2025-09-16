using TMPro;
using UnityEngine;

namespace GameCore
{
    /// <summary>
    /// Менеджер учета спасенных
    /// Singleton
    /// </summary>
    public class DistressedManager : MonoBehaviour
    {
        
        /// <summary>
        /// Singleton instanc
        /// </summary>
        public static DistressedManager Instance { private set; get; }
        
        /// <summary>
        /// Ссылка на UI счетчик спасенных 
        /// </summary>
        [SerializeField] private TextMeshProUGUI TextField;

        /// <summary>
        /// Количество реально спасенных овощей
        /// </summary>
        private int _count = 0;

        void Start()
        {
            Instance = this;
        }
        
        /// <summary>
        /// Добавить еще одного спасенного
        /// </summary>
        public void AddDistressed()
        {
            _count++;
            TextField.text = _count.ToString();
        }
    }
}