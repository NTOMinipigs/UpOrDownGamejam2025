using Unity.Mathematics.Geometry;
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

        [SerializeField] private Sprite[] _walkSprites;
        [SerializeField] private Sprite _staySprite;

        #endregion

        /// <summary>
        /// Текущий спрайт перемещения 
        /// </summary>
        private int _currentWalkSpriteIndex = 0;

        /// <summary>
        /// Задержка между сменой спрайтов
        /// </summary>
        [SerializeField] private float _spriteDuration = 0.2f;

        /// <summary>
        /// Последняя смена спрайта
        /// </summary>
        [SerializeField] private float _lastSpriteChange = 0f;

        /// <summary>
        /// При покидании зоны погони
        /// </summary>
        public override void OnChaseAreaLeaveTrigger()
        {
            // Если персонажу никуда не надо - ставим его прямо
            base.OnChaseAreaLeaveTrigger();
            _spriteRenderer.sprite = _staySprite;
            _currentWalkSpriteIndex = 0;
        }

        /// <summary>
        /// Возвращение на точку спавна
        /// </summary>
        public override void ToSpawnPoint()
        {
            base.ToSpawnPoint();

            // Если персонажу никуда не надо - ставим его прямо
            if (!wantToSpawn)
            {
                _spriteRenderer.sprite = _staySprite;
                _currentWalkSpriteIndex = 0;
            }
        }

        /// <summary>
        /// Метод перемещения персонажа
        /// </summary>
        /// <param name="pointTransform">место в которое стремится персонаж</param>
        protected override void Walk(Transform pointTransform)
        {
            base.Walk(pointTransform);

            // Поворачиваем астронавта в сторону ходьбы 
            if (pointTransform.position.x - transform.position.x < 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }

            // Если спрайт менять рано
            if (Time.time - _lastSpriteChange < _spriteDuration) return;

            // Воиспрозводим анимацию ходьбы
            _spriteRenderer.sprite = _walkSprites[_currentWalkSpriteIndex];
            if (_currentWalkSpriteIndex == _walkSprites.Length - 1) _currentWalkSpriteIndex = 0;
            else _currentWalkSpriteIndex++;
            _lastSpriteChange = Time.time;
        }

        /// <summary>
        /// Возвращает wantToSpawn 
        /// </summary>
        public bool WantToSpawn
        {
            get => wantToSpawn;
            set => wantToSpawn = value;
        }

        /// <summary>
        /// Геттер-сеттер для спавнпоинта
        /// </summary>
        public Transform SpawnPoint
        {
            get => spawnPoint;
            set => spawnPoint = value;
        }
    }
}