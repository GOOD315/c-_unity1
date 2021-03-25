using UnityEngine;

namespace Code
{
    public class CameraInGameController : IExecute, IInitialization
    {
        private readonly PlayerBall _player;
        private readonly Transform _mainCamera;

        public CameraInGameController(PlayerBall player, Transform camera)
        {
            _player = player;
            _mainCamera = camera;
        }

        public void Initialization()
        {
            StartLookAtPlayer();
        }

        public void Execute(float deltaTime)
        {
            UpdateLookAtPlayer();
        }

        public void StartLookAtPlayer()
        {
            UpdateLookAtPlayer();
            _mainCamera.LookAt(_player.transform);
        }

        private void UpdateLookAtPlayer()
        {
            var cameraX = _player.transform.position.x;
            var cameraY = _player.transform.position.y + 24;
            var cameraZ = _player.transform.position.z - 22;

            _mainCamera.position = new Vector3(cameraX, cameraY, cameraZ);
        }
    }
}