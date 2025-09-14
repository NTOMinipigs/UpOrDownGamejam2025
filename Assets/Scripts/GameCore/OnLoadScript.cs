using Unity.Cinemachine;
using UnityEngine;


namespace DefaultNamespace.GameCore
{
    /// <summary>
    /// Скрипт срабатывающий при открытии сцены Game
    /// </summary>
    public class OnLoadScript : MonoBehaviour
    {
        [SerializeField] private GameObject _camera;
        
        void Start()
        {
            // Получаем объект с данными из меню
            GameObject menuProxyGameObject = GameObject.Find("MenuProxyObject"); 
            MenuProxyObject menuProxyObject = menuProxyGameObject.GetComponent<MenuProxyObject>();

            // Ставим персонажа игроку
            Player.Instance.character =
                Instantiate(menuProxyObject.characterPrefab, new Vector2(0, 0), Quaternion.identity);

            // Подписываем камеру на персонажа
            _camera.GetComponent<CinemachineCamera>().Follow = Player.Instance.character.transform;
            _camera.GetComponent<CinemachineCamera>().LookAt = Player.Instance.character.transform;
            
            // Уничтожаем объекты со сцены, так как он больше не нужен
            Destroy(menuProxyObject);
            Destroy(gameObject);
        }
    }
}