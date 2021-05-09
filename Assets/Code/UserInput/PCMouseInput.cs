using UnityEngine;

namespace Code
{
    public class PCMouseInput
    {
        public Vector3 GetMouse()
        {
            return Input.mousePosition;
        }
    }
}