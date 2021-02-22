using System;
using Code;
using Traps;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

namespace Code
{
    public abstract class Trap : InteractiveObject, ICloneable
    {
        public override void Interaction(Collider col)
        {
            // CODE
            print($"{name} - SRABOTALA");
            Destroy(gameObject);
        }

        public object Clone()
        {
            var result = Instantiate(gameObject, transform.position, transform.rotation, transform.parent);
            return result;
        }

        public void Flay()
        {
        }
    }
}