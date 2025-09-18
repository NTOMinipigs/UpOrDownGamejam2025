using UnityEngine;

namespace GameCore
{
    /// <summary>
    /// Отвечает за открытие интерфейса с кодом
    /// </summary>
    public class OpenCodeInterface : MonoBehaviour
    {
        /// <summary>
        /// Объект хранящий в себе UI с вводом кода
        /// </summary>
        [SerializeField] private GameObject CodeMenu;

        /// <summary>
        /// Может ли меню быть открыто сейчас?
        /// </summary>
        private bool canOpen = false;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.C) && canOpen)
            {
                CodeMenu.SetActive(true);
            }
        }

        /// <summary>
        /// При входе в область в которой можно открыть меню
        /// </summary>
        /// <param name="other">Обязательный параметр</param>
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Character"))
            {
                canOpen = true;
                KeysManager.Instance.AddKey(KeysManager.Keys.C, "[C] Открыть меню ввода кода");
            }
        }

        /// <summary>
        /// При выходе из области в которой можно открыть меню
        /// </summary>
        /// <param name="other">Обязательный параметр</param>
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Character"))
            {
                canOpen = false;
                KeysManager.Instance.RemoveKey(KeysManager.Keys.C);
            }
        }
    }
}