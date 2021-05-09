using Code.Shooting;
using UnityEngine;

namespace Code.Enemy
{
    public class EnemyShoot : Shoot
    {
        public void DefaultShoot(GameObject bullet, Vector3 myPos, Vector3 aimPos)
        {
            base.DefaultShoot(bullet, myPos, aimPos);
        }
    }
}