using System;
using UnityEngine;
using UnityEngine.XR.WSA;

namespace Code
{
    public abstract class Trap : MonoBehaviour, ITrap
    {
        public abstract void TrapAction(Collider obj);
        public event Action<int, int> CallTrapControllerOnTrigger;
        public event Action<Trap> CallPlayerBonusesControllerOnTrigger;
        private Rigidbody _rigidbody;
        private Transform _transform;

        public TrapController trapController;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _transform = transform;
        }

        private void OnTriggerEnter(Collider obj)
        {
            CallTrapControllerOnTrigger?.Invoke(obj.gameObject.GetInstanceID(), gameObject.GetInstanceID());
            CallPlayerBonusesControllerOnTrigger?.Invoke(this);
            TrapAction(obj);
            Destroy(gameObject);
        }
    }
}