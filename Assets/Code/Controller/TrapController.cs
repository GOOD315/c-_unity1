using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class TrapController : IExecute, IInitialization
    {
        private int _currentActiveTraps;
        private int _maxActiveTraps;
        private readonly int _getInstanceID;


        private TrapInitialization trapInitialization;
        private TrapFactory _trapFactory;

        public int CurrentActiveTraps
        {
            get => _currentActiveTraps;
            set => _currentActiveTraps = value;
        }

        public TrapController(TrapFactory trapFactory, int getInstanceID)
        {
            _getInstanceID = getInstanceID;
            _trapFactory = trapFactory;
            trapInitialization = new TrapInitialization(_trapFactory, _getInstanceID, this);
        }

        public void CallController()
        {
        }

        public void Execute(float deltaTime)
        {
        }

        public void Initialization()
        {
            trapInitialization.SpawnTraps(10);
        }

        public void ChangeNumOfActiveTraps(int numb)
        {
            _currentActiveTraps += numb;
        }
    }
}