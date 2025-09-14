using UnityEngine;

namespace DefaultNamespace.GameCore
{
    /// <summary>
    /// Скрипт срабатывающий при открытии сцены Game
    /// </summary>
    public class OnLoadScript : MonoBehaviour
    {
        void Start()
        {
            // Получаем объект с данными из меню
            GameObject menuProxyGameObject = GameObject.Find("MenuProxyObject"); 
            MenuProxyObject menuProxyObject = menuProxyGameObject.GetComponent<MenuProxyObject>();

            // Выполняем скрипт
            Player.Instance.character =
                Instantiate(menuProxyObject.characterPrefab, new Vector2(0, 0), Quaternion.identity);

            // Уничтожаем объекты со сцены, так как он больше не нужен
            Destroy(menuProxyObject);
            Destroy(gameObject);
        }
    }
}