using UnityEngine;


namespace DefaultNamespace.GameCore
{


    public class CameraFollow2D : MonoBehaviour
    {
        public Transform target;       // персонаж
        public float smoothSpeed = 0.125f; // скорость сглаживания
        public Vector3 offset;         // смещение камеры (например, (0,0,-10))

        void LateUpdate()
        {
            if (target == null) return;

            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }

}