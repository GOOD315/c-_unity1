using UnityEngine;

namespace Code
{
    public class EndGameController : IInitialization, ICleanup
    {
        private readonly int _getInstanceID;
        private PlayerBall _player;

        public EndGameController()
        {
            _player = Reference.PlayerBall;
            _getInstanceID = _player.gameObject.GetInstanceID();
        }


        public void Initialization()
        {
            _player.TriggerOnDie += EndGame;
        }

        public void Cleanup()
        {
        }

        public void EndGame()
        {
            Debug.Log("ВЫ УБИТЫ");
            Reference.MenuCanvas.EndGame();
        }
    }
}