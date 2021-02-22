using UnityEngine;

namespace Code
{
    public class SlowTrap : Trap
    {
        public override void Interaction(Collider col)
        {
            base.Interaction(col);
            if (col.TryGetComponent(out IChangeSpeed changeSpeed))
            {
                changeSpeed.ChangeSpeed(-50f);
            }
        }
    }
}