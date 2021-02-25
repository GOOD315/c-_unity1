using UnityEngine;

namespace Code
{
    public sealed class HealingTrap : Trap
    {
        public override void Interaction(Collider col)
        {
            base.Interaction(col);
            if (col.TryGetComponent(out IApplyHeal applyHeal))
            {
                applyHeal.ApplyHeal(10f);
            }
        }
    }
}