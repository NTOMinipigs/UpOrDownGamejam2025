using UnityEngine;


namespace Enemies
{
    /// <summary>
    /// Скрипт для области видимости врага
    /// </summary>
    public class VisibilityAreaScript : MonoBehaviour
    {
        [SerializeField] private AbstractEnemy _enemyObject;

        void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Character"))
                _enemyObject.VisibilityAreaTrigger();
        }
        
    }
}