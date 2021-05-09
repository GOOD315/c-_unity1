using System.Collections;
using UnityEngine;

namespace Code.Enemy
{
    public class MoveRandomiser
    {
        public Vector3 getRandomMoveDirection()
        {
            float x = Random.Range(-360, 360);
            float y = 0f;
            float z = Random.Range(-360, 360);
            return new Vector3(x, y, z);
        }
    }
}