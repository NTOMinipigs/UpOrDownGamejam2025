using UnityEngine;


namespace Enemies
{
    /// <summary>
    /// Скрипт для области атаки врага
    /// </summary>
    public class AttackAreaScript : MonoBehaviour
    {

        [SerializeField] private AbstractEnemy _enemyObject;
        
        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Character")) _enemyObject.Attack();
        }
    }
}