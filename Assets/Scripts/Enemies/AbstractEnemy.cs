using Characters;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;


namespace Enemies
{
    /// <summary>
    /// Класс который должны наследовать все *Enemy классы
    /// </summary>
    public abstract class AbstractEnemy : MonoBehaviour, IEnemy
    {
        #region unity fields

        /// <summary>
        /// Точка спавна врага
        /// </summary>
        [SerializeField] public Transform spawnPoint;
        
        #endregion
        
        
        #region primetive fields
        
        /// <summary>
        /// Урон за один удар по игроку
        /// </summary>
        float _damage = 1;

        /// <summary>
        /// Скорость персонажа 
        /// </summary>
        float _speed = 1;

        /// <summary>
        /// Находится ли игрок сейчас в погоне7
        /// </summary>
        bool _isChase = false;

        /// <summary>
        /// Когда началась погоня
        /// </summary>
        float _chaseStartedAt = 0f;
        
        /// <summary>
        /// Продолжительность погони
        /// </summary>
        float _chaseDuration = 15f;

        /// <summary>
        /// Нужно к точке спавна
        /// </summary>
        private bool _wantToSpawn = true;
        
        #endregion
        
        /// <summary>
        /// Update unity method
        /// </summary>
        void Update()
        {
            if (_wantToSpawn)
            {
                ToSpawnPoint();
            }
            else if (_isChase)
            {
                Chase();
            }
        }
        
        /// <summary>
        /// Действие выполняющееся каждый кадр во время погони
        /// </summary>
        public void Chase()
        {
            // Отменяем погоню, если она идет слишком долго
            if (Time.time - _chaseStartedAt > _chaseDuration) _isChase = false;
            
            // Получаем вектор движения
            Vector3 movement;
            if (Player.Instance.character.transform.position.x - transform.position.x > 0) {
                movement = new Vector3(_speed, 0, 0);
            }
            else
            {
                movement = new Vector3(-_speed, 0, 0);
            }
            
            // Перемещаем
            transform.Translate(movement, Space.World);
        }

        /// <summary>
        /// Атака на игрока
        /// </summary>
        public void Attack()
        {
            Player.Instance.character.GetComponent<AbstractCharacter>().Damage(_damage);
        }

        /// <summary>
        /// Действие выполняющееся при попадании игрока в зону видимости 
        /// </summary>
        public void VisibilityAreaTrigger()
        {
            _chaseStartedAt = Time.time;
            _isChase = true;
        }

        /// <summary>
        /// При покидании зоны погони
        /// </summary>
        public void OnChaseAreaLeaveTrigger()
        {
            _isChase = false;
            _wantToSpawn = true;
        }

        /// <summary>
        /// Возвращение на точку спавна
        /// </summary>
        public void ToSpawnPoint()
        {
            // Прооверяем, не находится ли персонаж на текущем месте
            if (Mathf.Approximately(spawnPoint.position.x, transform.position.x)) { 
                _wantToSpawn=false;
                return;
            }
            
            // Получаем вектор движения
            Vector3 movement;
            if (spawnPoint.position.x - transform.position.x > 0) {
                movement = new Vector3(_speed, 0, 0);
            }
            else
            {
                movement = new Vector3(-_speed, 0, 0);
            }
            
            // Перемещаем
            transform.Translate(movement, Space.World);
        }
    }
}