using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class TrapController : IInitialization
    {
        private Dictionary<int, GameObject> _currentActiveTraps;
        private int _maxActiveTraps;
        private readonly int _getInstanceID;

        private TrapInitialization _trapInitialization;
        private TrapFactory _trapFactory;
        private TrapData _trapData;
        private PlayerBonusesController _playerBonusesController;

        public Dictionary<int, GameObject> CurrentActiveTraps => _currentActiveTraps;

        public TrapController(TrapFactory trapFactory, int getInstanceID,
            PlayerBonusesController playerBonusesController)
        {
            _getInstanceID = getInstanceID;
            _trapFactory = trapFactory;
            _trapData = trapFactory.Data;
            _playerBonusesController = playerBonusesController;
            _currentActiveTraps = new Dictionary<int, GameObject>();
            _trapInitialization =
                new TrapInitialization(_trapFactory, _getInstanceID, this, _playerBonusesController, _trapData);
        }


        public void Initialization()
        {
            _trapInitialization.SpawnTraps(10);
        }

        public void AddActiveTrap(GameObject trapObj)
        {
            _currentActiveTraps.Add(trapObj.GetInstanceID(), trapObj);
        }

        public void RemoveActiveTrap(int instanceID)
        {
            _currentActiveTraps.Remove(instanceID);
        }

        public void RemoveAllTraps()
        {
            foreach (var trap in _currentActiveTraps)
            {
                GameObject.Destroy(trap.Value);
            }
            
            _currentActiveTraps = new Dictionary<int, GameObject>();
            
        }

        public void LoadTraps()
        {
        }
    }
}