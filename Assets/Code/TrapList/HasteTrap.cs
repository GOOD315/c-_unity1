using System;
using Code.Buffs;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

namespace Code
{
    public sealed class HasteTrap : Trap
    {
        private void Awake()
        {
            trapType = TrapType.HasteTrap;
            trapBuff = new HasteBuff();
        }

        public override void TrapAction(Collider col)
        {
        }
    }
}