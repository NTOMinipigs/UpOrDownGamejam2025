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
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            Player.Instance.character.GetComponent<ICharacter>().Walk(horizontalInput);
        }
    }
}