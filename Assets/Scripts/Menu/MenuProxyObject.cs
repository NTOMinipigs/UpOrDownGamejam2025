using UnityEngine;


namespace DefaultNamespace.GameCore
{
    /// <summary>
    /// Объект для прокидывания данных из меню в основную игру
    /// </summary>
    public class MenuProxyObject : MonoBehaviour
    {
        public GameObject characterPrefab;
        public bool newGame = true;
        
        void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}