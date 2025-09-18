using System.Collections;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameCore
{
    /// <summary>
    /// Скрипт ввода кода
    /// </summary>
    public class CodeEnterScript : MonoBehaviour
    {

        [SerializeField] private GameObject warning;
        [SerializeField] private GameObject codeInputMenu;
        [SerializeField] private TextMeshProUGUI inputField;
        
        /// <summary>
        /// Правильный код
        /// </summary>
        private const string realCode = "4019​";
        
        void Update()
        {
            // Закрываем меню если нажата кнопка Escape
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                codeInputMenu.SetActive(false);
            }
        }
        
        /// <summary>
        /// Ввод кода
        /// </summary>
        public void CodeEnter()
        {
            string code = inputField.text;
            
            if (code.Trim() == realCode)
            {
                EndingProxyObject.Instance.endingType = EndingProxyObject.EndingType.Good;
                EndingProxyObject.Instance.gameStartedAt = Time.time;
                EndingProxyObject.Instance.distressedCount = DistressedManager.Instance.count;
                EndingProxyObject.Instance.lives = LivesManager.Instance.Lives;
                SceneManager.LoadScene("Ending");
            }
            else
            {
                StartCoroutine(ShowWarning());
            }
        }

        /// <summary>
        /// Показать сообщение о том, что код неверный
        /// </summary>
        /// <returns>Корутина</returns>
        IEnumerator ShowWarning()
        {
            warning.SetActive(true);
            yield return new WaitForSeconds(5);
            warning.SetActive(false);
        }
    }
}