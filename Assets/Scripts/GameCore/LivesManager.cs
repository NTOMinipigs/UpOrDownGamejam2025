using DefaultNamespace;
using UnityEngine;

namespace GameCore
{
    /// <summary>
    /// Менеджер управления жизнями игрока 
    /// </summary>
    public class LivesManager : MonoBehaviour
    {
        #region UI elements

        [SerializeField] private GameObject _firstHeart;
        [SerializeField] private GameObject _secondHeart;
        [SerializeField] private GameObject _thirdHeart;

        #endregion

        /// <summary>
        /// LivesManager is Singleton, this getter
        /// </summary>
        public static LivesManager Instance { private set; get; }

        /// <summary>
        /// Количество оставшихся жизней
        /// </summary>
        private int _lives = 3;

        void Start()
        {
            Instance = this;
        }
        
        /// <summary>
        /// Вызвать при смерти игрока
        /// </summary>
        public void Dead()
        {
            _lives -= 1;
            if (_lives == 0)
            {
                // TODO: Реализовать конец игры
            }

            // Удаляем жизни из UI
            if (_lives == 2) _thirdHeart.SetActive(false);
            else if (_lives == 1) _secondHeart.SetActive(false);
            
            // Телепортируем игрока назад
            StartCoroutine(FadeImage.Instance.FadeScreen());
            Player.Instance.character.transform.position = Vector3.zero;
        }
    }
}