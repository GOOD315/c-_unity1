using Code.Shooting;
using UnityEngine;

namespace Code
{
    public sealed class PlayerShootController : IExecute
    {
        private PlayerShoot _playerShoot;
        private GameObject _bullet;
        private PlayerBall _player;

        public PlayerShootController(PlayerBall player)
        {
            _player = player;
            _playerShoot = new PlayerShoot(player);

            _bullet = Resources.Load<GameObject>("MyAssets/Bullets/Bullet1");
        }

        public void Execute(float deltaTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _playerShoot.DefaultShoot(_bullet);
            }
        }
    }
}