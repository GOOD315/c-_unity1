using System.Collections.Generic;
using Code.Shooting;
using UnityEngine;

namespace Code.Enemy
{
    public class EnemyController : IExecute
    {
        private List<Enemy> _enemies;
        private Transform _player;

        private EnemyFactory _enemyFactory;

        EnemyController(Transform player)
        {
            this._player = player;
            _enemies = new List<Enemy>();
        }

        public void CreateEnemies(float number, float interval = 0f)
        {
            _enemies.Add(_enemyFactory.CreateEnemy());
        }

        public void Execute(float deltaTime)
        {
            foreach (var enemy in _enemies)
            {
                enemy.Move(deltaTime);
                enemy.Shoot(_player.position);
            }
        }
    }
}