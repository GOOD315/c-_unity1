using UnityEngine;

namespace Code
{
    public interface ITrapFactory
    {
        GameObject CreateTrap(GameObject trap, Transform pos);
    }
}