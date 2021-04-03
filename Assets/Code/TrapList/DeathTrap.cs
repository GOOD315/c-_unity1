using System;
using Code.Buffs;
using UnityEngine;

namespace Code
{
    public class DeathTrap : Trap
    {
        private void Awake()
        {
            trapType = TrapType.DeathTrap;
            trapBuff = new DeathBuff();
        }

        public override void TrapAction(Collider col)
        {
        }
    }
}