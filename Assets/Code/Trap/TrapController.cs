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
        private TrapList _trapList;
        private PlayerBonusesController _playerBonusesController;

        public Dictionary<int, GameObject> CurrentActiveTraps => _currentActiveTraps;

        public TrapController(TrapFactory trapFactory, int getInstanceID,
            PlayerBonusesController playerBonusesController, TrapList trapList)
        {
            _getInstanceID = getInstanceID;
            _trapFactory = trapFactory;
            _trapList = trapList;
            _playerBonusesController = playerBonusesController;
            _currentActiveTraps = new Dictionary<int, GameObject>();
            _trapInitialization =
                new TrapInitialization(_trapFactory, _getInstanceID, this, _playerBonusesController, _trapList);
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
        
    }
}