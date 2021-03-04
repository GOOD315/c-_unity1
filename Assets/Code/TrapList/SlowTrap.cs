using UnityEngine;

namespace Code
{
    public sealed class SlowTrap : Trap
    {
        public override void TrapAction(Collider col)
        {
            if (col.TryGetComponent(out IChangeSpeed changeSpeed))
            {
                changeSpeed.ChangeSpeed(-50f);
            }
        }
    }
}