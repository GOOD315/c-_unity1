using UnityEngine;

namespace Code
{
    public class DeathTrap : Trap
    {
        public delegate void CaughtPlayerChange();
        public CaughtPlayerChange CaughtPlayer;

        public override void Interaction(Collider col)
        {
            base.Interaction(col);
            print("ubil");
            CaughtPlayer();
        }
    }
}