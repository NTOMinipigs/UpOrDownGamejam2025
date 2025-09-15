using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// Класс врага-астронавта
    /// </summary>
    public class AstronautEnemy : AbstractEnemy
    {
        #region Unity objects

        /// <summary>
        /// Спрайт астронавта
        /// </summary>
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        #endregion
    }
}