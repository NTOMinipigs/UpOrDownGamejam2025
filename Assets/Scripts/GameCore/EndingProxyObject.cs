using UnityEngine;

namespace GameCore
{
    /// <summary>
    /// Прокси объект между сценой с игрой и сценой с концовкой
    /// </summary>
    public class EndingProxyObject : MonoBehaviour
    {
        
        /// <summary>
        /// Singleton member
        /// </summary>
        public static EndingProxyObject Instance { private set; get; }
        
        /// <summary>
        /// Тип концовки
        /// </summary>
        public enum EndingType
        {
            Good,
            Bad
        }
        
        /// <summary>
        /// Начало игры
        /// </summary>
        public float gameStartedAt = 0;
        
        /// <summary>
        /// Количество спасенных
        /// </summary>
        public int distressedCount = 0;

        /// <summary>
        /// Количество оставшихся жизней
        /// </summary>
        public int lives = 0;
        
        /// <summary>
        /// Тип концовки
        /// </summary>
        public EndingType endingType;

        void Start()
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}