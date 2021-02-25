using System;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

namespace Code
{
    public sealed class HasteTrap : Trap
    {
        public override void Interaction(Collider col)
        {
            base.Interaction(col);
            if (col.TryGetComponent(out IChangeSpeed changeSpeed))
            {
                changeSpeed.ChangeSpeed(100f);
            }
        }
    }
}