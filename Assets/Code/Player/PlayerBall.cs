using System;
using UnityEngine;

namespace Code
{
    public sealed class PlayerBall : MonoBehaviour
    {
        private float _health;
        private float _speed;
        private Rigidbody _rigidBody;
        [SerializeField] private PlayerData _playerData;
        public event Action TriggerOnDie;

        public float Speed
        {
            get => _speed;
            set
            {
                _speed = value;
                if (_speed < 0) _speed = 0;
            }
        }

        public float Health
        {
            get => _health;
            set
            {
                _health = value;
                if (_health <= 0) Die();
            }
        }

        private void Awake()
        {
            _rigidBody = gameObject.GetComponent<Rigidbody>();
        }

        private void Start()
        {
            _speed = _playerData.Speed;
            _health = _playerData.Health;
        }

        internal void Move(Vector3 moveDirection)
        {
            _rigidBody.AddForce(moveDirection * _speed);
        }

        internal void Die()
        {
            TriggerOnDie?.Invoke();
        }
    }
}