using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code
{
    public class LocationsLoader : MonoBehaviour, IController
    {
        private GameStarter _gameStarter;
        private bool _isPaused = true;

        private outLevelControllers outLevelControllers;
        private CameraIdleController cameraController;

        public bool IsPaused
        {
            get => _isPaused;
            set => _isPaused = value;
        }

        private void Awake()
        {
            outLevelControllers = new outLevelControllers();
        }

        private void Start()
        {
            initializeOutLevelControllers();
            outLevelControllers.Initialization();
        }

        private void initializeOutLevelControllers()
        {
            var _camera = Camera.main;
            outLevelControllers.Add(new CameraIdleController(_camera.transform));
        }

        public void LoadLocation()
        {
            _gameStarter = new GameStarter();
            _isPaused = false;
        }

        private void Update()
        {
            var time = Time.deltaTime;
            // наверное это неправильно - делать if в апдейте, но я честно пытался придумать как можно без него, и не придумал
            if (_isPaused)
            {
                outLevelControllers.Execute(time);
            }
            else
            {
                _gameStarter.Execute(time);
            }
        }

        private void LateUpdate()
        {
            var time = Time.deltaTime;
            if (_isPaused)
            {
                outLevelControllers.LateExecute(time);
            }
            else
            {
                _gameStarter.LateExecute(time);
            }
        }
    }
}