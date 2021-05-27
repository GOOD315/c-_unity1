using UnityEngine;

namespace Code.Enemy
{
    public class HealAbility : Ability
    {
        public HealAbility(string name, int damage, Target target, DamageType damageType) : base(name, damage, target, damageType)
        {
        }

        public override void Use()
        {
            Debug.Log("press f");
        }
    }
}