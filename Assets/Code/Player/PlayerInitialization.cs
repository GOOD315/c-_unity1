using UnityEngine;

namespace Code
{
    public sealed class PlayerInitialization : IInitialization
    {
        private readonly IPlayerFactory _playerFactory;
        private PlayerBall _player;

        public PlayerInitialization(IPlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
            _player = _playerFactory.CreatePlayer();
        }

        public void Initialization()
        {
        }

        public PlayerBall GetPlayer()
        {
            return _player;
        }
    }
}