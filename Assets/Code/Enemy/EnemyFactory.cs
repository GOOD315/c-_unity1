using UnityEngine;

namespace Code.Enemy
{
    public class EnemyFactory
    {
        private GameObject enemyPrefab;

        public Enemy CreateEnemy()
        {
            var enemy = GameObject.Instantiate(enemyPrefab, new Vector3(), Quaternion.identity);
            return enemy.GetComponent<Enemy>();
        }
    }
}