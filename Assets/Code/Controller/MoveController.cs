using UnityEditor.Build;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Code
{
    public class MoveController : IExecute, ICleanup
    {
        private readonly PlayerBall _unit;
        private readonly Rigidbody _unitRigidBody;
        private readonly IUnit _unitData;
        private float _horizontal;
        private float _vertical;
        private Vector3 _moveDirection;
        private IUserInputProxy _horizontalInputProxy;
        private IUserInputProxy _verticalInputProxy;

        public MoveController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input, PlayerBall unit,
            IUnit unitData)
        {
            _unit = unit;
            _unitRigidBody = _unit.GetComponent<Rigidbody>();
            _unitData = unitData;
            _horizontalInputProxy = input.inputHorizontal;
            _verticalInputProxy = input.inputVertical;
            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange += VerticalOnAxisOnChange;
        }

        private void HorizontalOnAxisOnChange(float value)
        {
            _horizontal = value;
        }

        private void VerticalOnAxisOnChange(float value)
        {
            _vertical = value;
        }

        public void Execute(float deltaTime)
        {
            var speed = _unitData.Speed;
            _moveDirection.Set(_horizontal, 0.0f, _vertical);
            _unit.Move(_moveDirection);
        }

        public void Cleanup()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisOnChange;
        }
    }
}