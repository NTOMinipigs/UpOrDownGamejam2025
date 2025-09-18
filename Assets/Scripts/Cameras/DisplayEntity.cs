using GameCore;
using UnityEngine;

namespace DefaultNamespace.Cameras
{
    public class DisplayEntity : MonoBehaviour
    {
        
        /// <summary>
        /// Может ли планшет быть подобранным?
        /// </summary>
        private bool canBePickedUp = false;
        
        void Update()
        {
            if (canBePickedUp && Input.GetKeyDown(KeyCode.R))
            {
                Player.Instance.cameraDisplay = true;
                KeysManager.Instance.RemoveKey(KeysManager.Keys.R);
                KeysManager.Instance.AddKey(KeysManager.Keys.Tab, "[Tab] Открыть планшет");
                Destroy(gameObject.transform.parent.gameObject);
            }
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            canBePickedUp = true;
            KeysManager.Instance.AddKey(KeysManager.Keys.R, "[R] Подобрать планшет");
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            canBePickedUp = false;
            KeysManager.Instance.RemoveKey(KeysManager.Keys.R);
        }
    }
}