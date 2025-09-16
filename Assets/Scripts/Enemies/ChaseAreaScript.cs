using UnityEngine;


namespace Enemies
{
    /// <summary>
    /// Скрипт для области погони врага
    /// </summary>
    public class ChaseAreaScript : MonoBehaviour
    {
        [SerializeField] private AbstractEnemy _enemyObject;

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Character"))
            {
                _enemyObject.Chase();
            }            
        }
    }
}