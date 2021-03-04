using System;
using Traps;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code
{
    public abstract class GoodTrap0 : Trap0, IFlay
    {
        private float _lengthFlay;

        private void Awake()
        {
            _lengthFlay = Random.Range(1.0f, 5.0f);
        }

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFlay),
                transform.localPosition.z);
        }
    }
}