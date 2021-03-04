using System;
using Code;
using Traps;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

namespace Code
{
    public abstract class Trap0 : InteractiveObject, ICloneable
    {
        // public delegate void callTrapController(TrapSpawnController controller);

        // public TrapSpawnController controller;
        // public callTrapController callController;


        public override void Interaction(Collider col)
        {
            // CODE
            // callController(controller);
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