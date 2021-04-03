using UnityEngine;

namespace Code
{
    public interface IPlayerFactory
    {
        PlayerBall CreatePlayer();
    }
}