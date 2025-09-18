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
        [SerializeField] protected float damage = 1;

        /// <summary>
        /// Скорость персонажа 
        /// </summary>
        [SerializeField] protected float speed = 1;

        /// <summary>
        /// Находится ли игрок сейчас в погоне7
        /// </summary>
        [SerializeField] protected bool isChase = false;

        /// <summary>
        /// Когда началась погоня
        /// </summary>
        [SerializeField] protected float chaseStartedAt = 0f;

        /// <summary>
        /// Продолжительность погони
        /// </summary>
        [SerializeField] protected float chaseDuration = 15f;

        /// <summary>
        /// Нужно к точке спавна
        /// </summary>
        [SerializeField] protected bool wantToSpawn = false;

        /// <summary>
        /// Задержка между аттаками
        /// </summary>
        [SerializeField] protected float attackDelay = 1f;

        /// <summary>
        /// Время последней атаки
        /// </summary>
        [SerializeField] protected float lastAttack = 0f;

        #endregion

        /// <summary>
        /// Update unity method
        /// </summary>
        void FixedUpdate()
        {
            if (wantToSpawn)
            {
                ToSpawnPoint();
            }
            else if (isChase)
            {
                Chase();
            }
        }

        /// <summary>
        /// Действие выполняющееся каждый кадр во время погони
        /// </summary>
        public virtual void Chase()
        {
            if (!isChase) return;
            
            // Отменяем погоню, если она идет слишком долго
            if (Time.time - chaseStartedAt > chaseDuration) OnChaseAreaLeaveTrigger();
            
            Walk(Player.Instance.character.transform);
        }

        /// <summary>
        /// Атака на игрока
        /// </summary>
        public virtual void Attack()
        {
            if (Time.time - lastAttack > attackDelay)
            {
                Player.Instance.character.GetComponent<AbstractCharacter>().Damage(damage);
                lastAttack = Time.time;
            }
        }

        /// <summary>
        /// Действие выполняющееся при попадании игрока в зону видимости 
        /// </summary>
        public virtual void VisibilityAreaTrigger()
        {

            AudioLoop gameLoop = MusicManager.Singleton.AudioLoops["GameLoop"];
            if (gameLoop.CurrentAudio != null && gameLoop.CurrentAudio.Source.isPlaying)
            {
                gameLoop.Stop(fadeEffect: true);
                MusicManager.Singleton.Audios["SnowBeer"].Source.time = 15f;
                MusicManager.Singleton.AudioLoops["ChaseLoop"].Play();
            }

            chaseStartedAt = Time.time;
            isChase = true;
        }

        /// <summary>
        /// При покидании зоны погони
        /// </summary>
        public virtual void OnChaseAreaLeaveTrigger()
        {
            isChase = false;
            wantToSpawn = true;
            
            MusicManager.Singleton.AudioLoops["ChaseLoop"].Stop(fadeEffect: true);
            MusicManager.Singleton.AudioLoops["GameLoop"].Play();
        }

        /// <summary>
        /// Возвращение на точку спавна
        /// </summary>
        public virtual void ToSpawnPoint()
        {
            // Если нет точки спавна, удалить объект
            if (spawnPoint == null)
            {   
                Destroy(gameObject);
                return;
            }
            
            // Прооверяем, не находится ли персонаж на текущем месте
            if (Mathf.Abs(spawnPoint.position.x - transform.position.x) < 1)
            {
                wantToSpawn = false;
                return;
            }
            Walk(spawnPoint);
        }

        /// <summary>
        /// Метод перемещения персонажа
        /// </summary>
        /// <param name="pointTransform">место в которое стремится персонаж</param>
        protected virtual void Walk(Transform pointTransform)
        {
            // Получаем вектор движения
            Vector3 movement;
            if (pointTransform.position.x - transform.position.x > 0)
            {
                movement = new Vector3(speed, 0, 0) * Time.deltaTime;
            }
            else
            {
                movement = new Vector3(-speed, 0, 0) * Time.deltaTime;
            }

            // Перемещаем
            transform.Translate(movement, Space.World);
        }
    }
}