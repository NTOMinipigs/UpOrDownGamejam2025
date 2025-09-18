using GameCore;
using Unity.Cinemachine;
using UnityEngine;

namespace DefaultNamespace.Cameras
{
    /// <summary>
    /// Менеджер управления камерами
    /// </summary>
    public class DisplayManager : MonoBehaviour
    {
        [SerializeField] private CinemachineCamera[] _cameras;
        [SerializeField] private CinemachineCamera _mainCamera;
        private int currentCamera = 0;
        [SerializeField] private GameObject _display;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab) && Player.Instance.cameraDisplay)
            {
                _display.SetActive(true);
                _mainCamera.Priority = 0;
                _cameras[currentCamera].Priority = 100;
                
                KeysManager.Instance.AddKey(KeysManager.Keys.WS, "[ W S ] Для смены камеры");
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _display.SetActive(false);
                _mainCamera.Priority = 100;
                KeysManager.Instance.RemoveKey(KeysManager.Keys.WS);
            }
            
            if (Input.GetKeyDown(KeyCode.W) && Player.Instance.cameraDisplay) NextCamera(-1);
            if (Input.GetKeyDown(KeyCode.S) && Player.Instance.cameraDisplay) NextCamera(1);
        }

        public void NextCamera(int direction)
        {
            int oldCamera = currentCamera;
            currentCamera += direction;
            if (currentCamera < 0) currentCamera = _cameras.Length - 1;
            if (currentCamera >= _cameras.Length) currentCamera = 0;
            _cameras[currentCamera].Priority = 100;
            _cameras[oldCamera].Priority = 0;
        }
        
        
    }
}