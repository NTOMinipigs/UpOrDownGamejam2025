using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace MenuNamespace
{

    /// <summary>
    /// Класс отвечающий за все события в Menu
    /// </summary>
    public class MainMenuScript : MonoBehaviour
    {
        /// <summary>
        /// Объект содержащий все canvas элементы с основного меню
        /// </summary>
        
        [FormerlySerializedAs("_main")] [SerializeField] private GameObject main;

        /// <summary>
        /// Объект содержащий canvas элементы настроек
        /// </summary>
        [FormerlySerializedAs("_settigs")] [SerializeField] private GameObject settigs;
        
        /// <summary>
        /// Объект содержащий canvas элементы выбора персонажа 
        /// </summary>
        [FormerlySerializedAs("_selectCharacter")] [SerializeField] private GameObject selectCharacter;
        
        /// <summary>
        /// Событие при нажатии кнопки новая игра
        /// </summary>
        public void OnNewGameButtonClick()
        {
            main.SetActive(false);
            selectCharacter.SetActive(true);
            
        }
        
        /// <summary>
        /// Событие при нажатии кнопки продолжить игру
        /// </summary>
        public void OnContinueButtonClick()
        {
            SceneManager.LoadScene("Game");
        }
        
        /// <summary>
        /// Событие при нажатии кнопки настройки 
        /// </summary>
        public void OnOptionsButtonClick()
        {
            main.SetActive(false);
            settigs.SetActive(true);
        }
        
        /// <summary>
        /// Событие при нажатии кнопки выйти из игры
        /// </summary>
        public void OnQuitButtonClick()
        {
            Application.Quit();
        }
    }
}