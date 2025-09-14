using Characters;
using UnityEngine;

namespace DefaultNamespace
{
    /// <summary>
    /// Объект игрока
    /// Singleton
    /// </summary>
    public class Player : MonoBehaviour
    {
        public static Player Instance { private set; get; }
        
        /// <summary>
        /// Объект персонажа
        /// </summary>
        public GameObject character;
        
        /// <summary>
        /// Назначить инстанс
        /// </summary>
        private void Awake()
        {
            Instance = this;
        }
        
    }
}