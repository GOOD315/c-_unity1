using System;
using Code.Buffs;
using Code.SaveData;
using UnityEngine;

namespace Code
{
    public sealed class SlowTrap : Trap
    {
        private void Awake()
        {
            trapType = TrapType.SlowTrap;
            trapBuff = new SlowBuff();
        }

        public override void TrapAction(Collider col)
        {
        }
    }
}