using System;
using System.Collections.Generic;
using Code.Buffs;
using UnityEngine;

namespace Code
{
    public sealed class DamageTrap : Trap
    {
        private void Awake()
        {
            trapType = TrapType.DamageTrap;
            trapBuff = new DamageBuff();
        }

        public override void TrapAction(Collider col)
        {
            if (col.TryGetComponent(out IApplyDamage applyDamage))
            {
                applyDamage.ApplyDamage(50f);
            }
        }
    }
}