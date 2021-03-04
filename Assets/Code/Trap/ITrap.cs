using System;

namespace Code
{
    public interface ITrap
    {
        event Action<int, TrapController> CallControllerOnTrigger;
    }
}