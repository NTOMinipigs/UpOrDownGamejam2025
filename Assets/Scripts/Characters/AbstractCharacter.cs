using System;
using GameCore;
using UnityEngine;
using UnityEngine.Serialization;


namespace Characters
{
    /// <summary>
    /// Класс который должны наследовать все классы Character
    /// </summary>
    public abstract class AbstractCharacter : MonoBehaviour, ICharacter
    {
        [Header("Movement Settings")] [FormerlySerializedAs("jumpForce")]
        public float walkJumpForce = 11f; // Сила прыжка

        [FormerlySerializedAs("jumpDistance")] public float walkJumpDistance = 15f; // Дистанция прыжка

        public float jumpPower = 200f;
        private bool isGrounded = true;
        /// <summary>
        /// TODO: написать документацию для этой ебейшей хуйни
        /// </summary>
        private bool inJump = false;

        protected Rigidbody2D Rb;
        protected Sprite BodySprite;
        protected string CharacterName;
        protected float Speed = 0.1f;

        void Start()
        {
            Rb = GetComponent<Rigidbody2D>();
            KeysManager.Instance.AddKey(KeysManager.Keys.Space, "[SPACE] - Прыжок");
            KeysManager.Instance.AddKey(KeysManager.Keys.AD, "[A, D] - Перемещение влево/вправо");
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
                inJump = false;
                Rb.linearVelocity = Vector2.zero;
                KeysManager.Instance.AddKey(KeysManager.Keys.Space, "[SPACE] - Прыжок");
                KeysManager.Instance.AddKey(KeysManager.Keys.AD, "[A, D] - Перемещение влево/вправо");
            }
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

            if (direction != 00 && isGrounded)
            {
                // Рассчитываем вектор прыжка
                Vector2 jumpVector = new Vector2(direction * walkJumpDistance, walkJumpForce);

                // Применяем силу прыжка
                Rb.AddForce(jumpVector, ForceMode2D.Impulse);

                isGrounded = false;
                KeysManager.Instance.RemoveKey(KeysManager.Keys.AD);
                return;
            }

            if (direction != 00 && inJump)
            {
                Vector2 jumpVector = new Vector2(direction * walkJumpDistance, 0);
                Rb.AddForce(jumpVector, ForceMode2D.Impulse);
                inJump = false;
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

            if (!isGrounded) return;
            Rb.linearVelocity = new Vector2(Rb.linearVelocity.x, jumpPower);
            isGrounded = false;
            inJump = true;
            KeysManager.Instance.RemoveKey(KeysManager.Keys.Space);
        }

        /// <summary>
        /// Использование способности
        /// </summary>
        public abstract void UseAbility();
    }
}