using UnityEditor;
using UnityEngine;

namespace Code
{
    public class GameStarter
    {
        [SerializeField] private Data _data;
        private Controllers _controllers;

        private void Start()
        {
            _controllers = new Controllers();
            new GameInitialization(_controllers, _data);
            _controllers.Initialization();
        }

        private void Update()
        {
        }

        private void LateUpdate()
        {
        }

        private void OnDestroy()
        {
        }
    }
}