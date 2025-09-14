using System;
using UnityEngine;


namespace Characters
{
    /// <summary>
    /// Класс который должны наследовать все классы Character
    /// </summary>
    public abstract class AbstractCharacter : MonoBehaviour, ICharacter
    {
        [Header("Movement Settings")]
        public float jumpForce = 11f;          // Сила прыжка
        public float jumpDistance = 15f;       // Дистанция прыжка
        public float jumpCooldown = 0.45f;     // Задержка между прыжками
        
        private float lastJumpTime = 0f;
        
        protected Rigidbody2D Rb;
        protected Sprite BodySprite;
        protected string CharacterName;
        protected float Speed = 0.1f;

        void Start()
        {
            Rb = GetComponent<Rigidbody2D>();
        }
        
        /// <summary>
        /// Метод, который должен вызываться в Start() методе
        /// </summary>
        protected void SetRigidbody()
        {
            Rb = GetComponent<Rigidbody2D>();
        }
        
        /// <summary>
        /// Перемещение персонажа
        /// </summary>
        /// <param name="direction">Направление движения (-1 или 1)</param>
        public void Walk(float direction)
        {
            // Проверка наличия rigidbody, в случае если его нет
            if (Rb == null)
            {
                throw new NullReferenceException(
                    "RigidBody is null. Call SetRigidbody() in Start() method of your class.");
            }

            if (direction != 00 && Time.time - lastJumpTime >= jumpCooldown) 
            {
                // Рассчитываем вектор прыжка
                Vector2 jumpVector = new Vector2(direction * jumpDistance, jumpForce);

                // Применяем силу прыжка
                //Rb.linearVelocity = new Vector2(0, Rb.linearVelocity.y); // Сбрасываем горизонтальную скорость
                Rb.AddForce(jumpVector, ForceMode2D.Impulse);

                lastJumpTime = Time.time;
            }
        }

        /// <summary>
        /// Прыжок персонажа
        /// </summary>
        public void Jump()
        {
            // Проверка наличия rigidbody, в случае если его нет
            if (Rb == null)
            {
                throw new NullReferenceException(
                    "RigidBody is null. Call SetRigidbody() in Start() method of your class.");
            }
        }

        /// <summary>
        /// Использование способности
        /// </summary>
        public abstract void UseAbility();
    }
}