using UnityEngine;


namespace Characters
{
    /// <summary>
    /// Скрипт отвечающий за анимацию глаз
    /// </summary>
    public class EyesAnimation : MonoBehaviour
    {
        /// <summary>
        /// Массив анимации глаз
        /// </summary>
        [SerializeField] private Sprite[] _sprites;

        /// <summary>
        /// Пауза между морганиями
        /// </summary>
        [SerializeField] private float _blinkPauseTime;

        /// <summary>
        /// Пауза между кадрами моргания
        /// </summary>
        [SerializeField] private float _blinkPauseFrames;

        /// <summary>
        /// Количество фреймов в анимации
        /// </summary>
        [SerializeField] private int _frames;

        /// <summary>
        /// Индекс текущего спрайта в массиве
        /// </summary>
        private int _currentSprite = 0;

        /// <summary>
        /// Время последней анимации
        /// </summary>
        private float _lastAnimationTime = 0;

        /// <summary>
        /// Время последнего обновления анимации
        /// </summary>
        private float _lastFrameTime = 0;

        /// <summary>
        /// Находится ли спрайт сейчас в анимации
        /// </summary>
        private bool _isAnimate = true;

        /// <summary>
        /// Спрайт рендерер который нужно обновлять
        /// </summary>
        private SpriteRenderer _spriteRenderer;

        void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            // if bling in progress
            if (_isAnimate)
            {
                // Если задержка между фреймами еще не прошла
                if (Time.time - _lastFrameTime < _blinkPauseFrames) return;

                // Если анимация закончилась
                if (_currentSprite >= _frames)
                {
                    _currentSprite = 0;
                    _isAnimate = false;
                    _lastFrameTime = Time.time;
                    _lastAnimationTime = Time.time;
                    _spriteRenderer.sprite = _sprites[_currentSprite];
                    return;
                }

                // Если анимация не закончилась
                _lastFrameTime = Time.time;
                _spriteRenderer.sprite = _sprites[_currentSprite];
                _currentSprite += 1;
            }

            // Если задержка между анимациями еще не прошла
            else
            {
                if (Time.time - _lastAnimationTime < _blinkPauseTime) return;
                _isAnimate = true;
            }
        }
    }
}