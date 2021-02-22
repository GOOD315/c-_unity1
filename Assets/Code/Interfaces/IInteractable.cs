using UnityEngine;
using UnityEngine.XR.WSA.Input;

namespace Code
{
    public interface IInteractable
    {
        void Interaction(Collider col);
    }
}