using Enemies;
using UnityEngine;


namespace GameCore
{
    /// <summary>
    /// Скрипт отвечающий за перемещение астронавта по коридору
    /// </summary>
    public class AstronautScript : MonoBehaviour
    {
        /// <summary>
        /// Объект астронавта
        /// </summary>
        [SerializeField] private AstronautEnemy astronaut;
        
        /// <summary>
        /// Первая точка
        /// </summary>
        [SerializeField] private Transform firstPoint;
        
        /// <summary>
        /// Вторая точка
        /// </summary>
        [SerializeField] private Transform secondPoint;


        void Update()
        {
            // Если астронавт на точке
            if (!astronaut.WantToSpawn)
            {
                
                // Меняем точку спавна астронавта
                if (astronaut.SpawnPoint == firstPoint) astronaut.SpawnPoint = secondPoint;
                else astronaut.SpawnPoint = firstPoint;
                
                // Отправляем в ту сторону
                astronaut.WantToSpawn = true;
            }
        }
    }
}