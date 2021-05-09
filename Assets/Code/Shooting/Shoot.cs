using UnityEngine;

namespace Code.Shooting
{
    public class Shoot : IShoot
    {
        public void DefaultShoot(GameObject bullet, Vector3 myPos, Vector3 aimPos)
        {
            var direction = (aimPos - myPos).normalized;
            var bulletObj = GameObject.Instantiate(bullet, myPos, Quaternion.identity);
            var bulletScr = bulletObj.GetComponent<Bullet>();
            bulletScr.speed = 50f;
            bulletScr.direction = direction;
        }
    }
}