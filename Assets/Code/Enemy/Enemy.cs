using System;
using Code.Shooting;
using UnityEditor.AnimatedValues;
using UnityEngine;

namespace Code.Enemy
{
    [RequireComponent(typeof(Rigidbody))]
    public class Enemy : MonoBehaviour, IEnemyMove
    {
        [SerializeField] GameObject bullet;
        private MoveRandomiser _moveRandomiser;
        private float _health;
        public Vector3 MoveDirection { get; private set; }
        public float DirectionCooldown { get; private set; }
        public float DirectionTimer { get; private set; }
        public float MoveSpeed { get; private set; }
        private Rigidbody _rigidbody;

        public EnemyShoot EnemyShoot;
        public EnemyAbilities EnemyAbilities;

        float Health
        {
            get { return _health; }
            set
            {
                _health = value;
                if (_health <= 0) Die();
            }
        }

        private void Start()
        {
            Health = 50f;
            MoveDirection = Vector3.forward;
            MoveSpeed = 5f;
            DirectionCooldown = 0.5f;
            DirectionTimer = 0;
            _moveRandomiser = new MoveRandomiser();
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Move(float deltaTime)
        {
            DirectionTimer += deltaTime;
            if (DirectionTimer >= DirectionCooldown)
            {
                MoveDirection = _moveRandomiser.getRandomMoveDirection();
                DirectionTimer = 0f;
            }

            _rigidbody.AddForce(MoveDirection * (MoveSpeed * deltaTime));
        }

        public void Shoot(Vector3 playerPos)
        {
            EnemyShoot.DefaultShoot(bullet, transform.position, playerPos);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Bullet>(out var bullet))
            {
                Health -= 25;
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }

        private void FixedUpdate()
        {
            Move(Time.fixedDeltaTime);
        }
    }
}