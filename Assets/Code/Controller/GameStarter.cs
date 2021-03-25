using System;
using UnityEditor;
using UnityEngine;

namespace Code
{
    // убрал у этого класса монобехевиор, что бы использовать его как типовой для начальной инициализации уровней,
    // и вызова на нем Execute и остальных функций
    public class GameStarter : IExecute, ICleanup, ILateExecute, IInitialization
    {
        [SerializeField] private Data _data;
        private inLevelControllers inLevelcontrollers;

        public GameStarter()
        {
            _data = Resources.Load<Data>("Data/Data");
            inLevelcontrollers = new inLevelControllers();
            new GameInitialization(inLevelcontrollers, _data);
            inLevelcontrollers.Initialization();
        }

        public void Initialization()
        {
        }

        public void Execute(float deltaTime)
        {
            inLevelcontrollers.Execute(deltaTime);
        }

        public void LateExecute(float deltaTime)
        {
            inLevelcontrollers.LateExecute(deltaTime);
        }

        public void Cleanup()
        {
            inLevelcontrollers?.Cleanup();
        }
    }
}