using System;
using UnityEngine;

namespace Code.Shooting
{
    public interface IShoot
    {
        void DefaultShoot(GameObject bullet, Vector3 myPos, Vector3 aimPos);
    }
}