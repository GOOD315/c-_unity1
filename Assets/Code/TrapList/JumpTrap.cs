using Code.Buffs;
using UnityEngine;

namespace Code
{
    public sealed class JumpTrap : Trap
    {
        private void Awake()
        {
            trapType = TrapType.HealingTrap;
            trapBuff = new JumpBuff();
        }

        public override void TrapAction(Collider col)
        {
        }
        
    }
}