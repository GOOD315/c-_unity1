using UnityEngine;

namespace Code
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Data/Settings/PlayerSettings")]
    public class PlayerData : ScriptableObject, IUnit
    {
        [SerializeField] private float _health;
        public PlayerBall playerScript;
        [SerializeField, Range(0, 100)] private float _speed;
        public Transform PlayerSpawnPoint;

        public float Speed => _speed;
        public float Health => _health;
    }
}