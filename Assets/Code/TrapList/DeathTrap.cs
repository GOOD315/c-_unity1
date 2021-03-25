using UnityEngine;

namespace Code
{
    public class DeathTrap : Trap
    {
        public override void TrapAction(Collider col)
        {
            if (col.TryGetComponent(out IApplyDamage applyDamage))
            {
                applyDamage.ApplyDamage(1000f);
            }
        }
    }
}