using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Code
{
    public class CameraIdleController : IExecute, IInitialization, ICleanup
    {
        private readonly Transform _mainCamera;

        private bool isLookingAtPlayer;
        private bool isIdle;
        private Vector3 startIdlePos;
        private float speed = 5f;

        public CameraIdleController(Transform mainCamera)
        {
            _mainCamera = mainCamera;
        }

        public void Initialization()
        {
            StartOnIdle();
        }

        public void Execute(float deltaTime)
        {
            UpdateOnIdle(deltaTime);
        }

        public void StartOnIdle()
        {
            _mainCamera.position = new Vector3(2.0f, 20.0f, -20.0f);
            _mainCamera.rotation = Quaternion.Euler(0, 0, 0);
        }

        private void UpdateOnIdle(float deltaTime)
        {
            // здесь должен быть полет по окружности над локацией
            _mainCamera.transform.Translate(-_mainCamera.transform.forward * (deltaTime * speed));
        }


        public void Cleanup()
        {
        }
    }
}