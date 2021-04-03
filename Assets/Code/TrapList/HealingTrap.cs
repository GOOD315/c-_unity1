using System;
using Code.Buffs;
using UnityEngine;

namespace Code
{
    public sealed class HealingTrap : Trap
    {
        private void Awake()
        {
            trapType = TrapType.HealingTrap;
            trapBuff = new HealingBuff();
        }

        public override void TrapAction(Collider col)
        {
        }
    }
}