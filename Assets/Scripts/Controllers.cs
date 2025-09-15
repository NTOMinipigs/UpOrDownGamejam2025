using Characters;
using UnityEngine;


namespace DefaultNamespace
{
    /// <summary>
    /// Класс отслеживающий нажатия кнопок
    /// </summary>
    public class Controllers : MonoBehaviour
    {
        void Update()
        {
            // Перемещение по горизонтали
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            if (horizontalInput != 0)
            {
                Player.Instance.character.GetComponent<ICharacter>().Walk(horizontalInput);
                return;
            }

            // Прыжки
            float jumpInput = Input.GetAxisRaw("Jump");
            if (jumpInput != 0)
            {
                Player.Instance.character.GetComponent<ICharacter>().Jump();
                return;
            }
            
            // Открыть дверь
            if (Input.GetKeyDown(KeyCode.T))
            {
                Player.Instance.character.GetComponent<ICharacter>().Teleport();
            }
            
        }
    }
}