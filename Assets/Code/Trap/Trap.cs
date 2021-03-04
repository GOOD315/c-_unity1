using System;
using UnityEngine;
using UnityEngine.XR.WSA;

namespace Code
{
    public abstract class Trap : MonoBehaviour, ITrap
    {
        public abstract void TrapAction(Collider obj);
        public event Action<int, TrapController> CallControllerOnTrigger;
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
            CallControllerOnTrigger?.Invoke(obj.gameObject.GetInstanceID(), trapController);
            TrapAction(obj);
            Destroy(this);
        }
    }
}