using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Code
{
    public sealed class PlayerBall : MonoBehaviour, IChangeSpeed, IApplyDamage, IApplyHeal
    {
        private bool _isDead;
        private float Speed = 100f;
        private float Health = 100f;
        private Rigidbody _rigidbody;

        private void Start()
        {
            _isDead = false;
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected void Move()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

            _rigidbody.AddForce(movement * Speed);
        }

        private void FixedUpdate()
        {
            Move();
            if (Health == 0) Die();
        }

        public void ChangeSpeed(float speed)
        {
            Speed += speed;
        }

        public void ApplyDamage(float damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
        }

        public void ApplyHeal(float heal)
        {
            if (Health <= 100) Health += heal;
        }

        private void Die()
        {
            _isDead = true;
            print("umer muzhik");
        }
    }
}