using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


// TODO: ADD DOCS
namespace GameCore
{
    /// <summary>
    /// Телепортер в другую локацию
    /// </summary>
    public class Teleporter : MonoBehaviour
    {
        [FormerlySerializedAs("_teleportTo")] [SerializeField]
        public Transform teleportTo;


        void Start()
        {
            GameObject.Find("FadeImage").GetComponent<Image>();
        }

        /// <summary>
        /// Телепортировать игрока в другую точку 
        /// </summary>
        public void Teleport(Rigidbody2D Rb)
        {
            StartCoroutine(FadeImage.Instance.FadeScreen());
            Rb.position = teleportTo.position;
            Rb.linearVelocity = Vector2.zero;
            Rb.angularVelocity = 0;
        }
    }
}