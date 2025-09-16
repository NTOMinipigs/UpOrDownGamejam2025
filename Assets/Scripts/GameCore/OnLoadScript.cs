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
            
            MusicManager.Singleton.AudioLoops["MenuLoop"].Stop(fadeEffect: true);
            
            
            // Ставим персонажа игроку
            Player.Instance.character =
                Instantiate(menuProxyObject.characterPrefab, new Vector2(0, 0), Quaternion.identity);

            // Подписываем камеру на персонажа
            _camera.GetComponent<CinemachineCamera>().Follow = Player.Instance.character.transform;
            _camera.GetComponent<CinemachineCamera>().LookAt = Player.Instance.character.transform;

            // Подгружаем треки
            InitAudios();
            
            // Запускаем катсцену
            StartGame();
            
            // Уничтожаем объекты со сцены, так как он больше не нужен
            Destroy(menuProxyObject);
            Destroy(gameObject);
        }

        void StartGame()
        {
            MusicManager.Singleton.AudioLoops["GameLoop"].Play();
        }

        void InitAudios()
        {
            Audio[] gameAudios = { MusicManager.Singleton.Audios["WindBeer"] };
            AudioLoop gameAudioLoop = new AudioLoop(gameAudios, volume: 0.2f, fadeEffect: true);
            MusicManager.Singleton.AudioLoops["GameLoop"] = gameAudioLoop;
            
            Audio[] chaseAudios = { MusicManager.Singleton.Audios["SnowBeer"] };
            AudioLoop chaseAudioLoop = new AudioLoop(chaseAudios, volume: 1f, fadeEffect: true);
            MusicManager.Singleton.AudioLoops["ChaseLoop"] = chaseAudioLoop;
        }
    }
}