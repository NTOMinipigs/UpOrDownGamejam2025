using Characters;
using UnityEngine;
using UnityEngine.Serialization;

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
        /// Время начала игры
        /// </summary>
        public float gameStartedAt;
        
        /// <summary>
        /// Объект персонажа
        /// </summary>
        public GameObject character;

        /// <summary>
        /// Может ли игрок открыть камеры?
        /// </summary>
        public bool cameraDisplay = false;
        
        /// <summary>
        /// Назначить инстанс
        /// </summary>
        private void Awake()
        {
            Instance = this;
            gameStartedAt = Time.time;
        }
        
    }
}