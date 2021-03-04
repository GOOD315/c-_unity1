using UnityEngine;

namespace Code
{
    public sealed class DamageTrap : Trap
    {
        public override void TrapAction(Collider col)
        {
            if (col.TryGetComponent(out IApplyDamage applyDamage))
            {
                applyDamage.ApplyDamage(50f);
            }
        }
    }
}