using UnityEngine;

namespace Code.Enemy
{
    public interface IEnemyMove
    {
        Vector3 MoveDirection { get; }
        float DirectionCooldown { get; }
        float DirectionTimer { get; }
        float MoveSpeed { get; }
        void Move(float deltaTime);
    }
}