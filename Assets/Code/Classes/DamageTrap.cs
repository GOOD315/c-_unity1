﻿using UnityEngine;

namespace Code
{
    public sealed class DamageTrap : Trap
    {
        public override void Interaction(Collider col)
        {
            base.Interaction(col);
            if (col.TryGetComponent(out IApplyDamage applyDamage))
            {
                applyDamage.ApplyDamage(1000f);
            }
        }
    }
}