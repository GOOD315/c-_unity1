using System;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

namespace Code
{
    public sealed class HasteTrap : Trap
    {
        public override void TrapAction(Collider col)
        {
            if (col.TryGetComponent(out IChangeSpeed changeSpeed))
            {
                changeSpeed.ChangeSpeed(100f);
            }
        }
    }
}