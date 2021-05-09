using System;
using UnityEngine;

namespace Code.Shooting
{
    public class Bullet : MonoBehaviour
    {
        internal float speed = 5;
        private float accelleration = 0;
        private float startingSpeed = 1;

        internal Vector3 direction;

        private void Update()
        {
            transform.position += direction * (Time.deltaTime * speed);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "Player") return;
            if (!other.gameObject.TryGetComponent(out Collider col)) return;
            Destroy(gameObject);
        }
    }
}