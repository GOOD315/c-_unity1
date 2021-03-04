using UnityEngine;

namespace Code
{
    public interface ITrapFactory
    {
        GameObject CreateTrap(int index, Transform pos);
    }
}