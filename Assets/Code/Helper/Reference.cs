using Code.Canvas;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Code
{
    public static class Reference
    {
        private static PlayerBall _playerBall;
        private static Camera _mainCamera;
        private static CanvasController _menuCanvas;
        private static TrapController _trapController;
        private static PlayerBonusesController _playerBonusesController;
        private static TrapData _trapData;
        private static BuffData _buffData;

        public static PlayerBall PlayerBall
        {
            get
            {
                if (_playerBall == null)
                {
                    var gameObject = GameObject.FindWithTag("Player");
                    _playerBall = gameObject.GetComponent<PlayerBall>();
                }
                
                return _playerBall;
            }
        }

        public static Camera MainCamera
        {
            get
            {
                if (_mainCamera == null) _mainCamera = Camera.main; 
                
                return _mainCamera;
            }
        }

        public static CanvasController MenuCanvas
        {
            get
            {
                if (_menuCanvas == null)
                {
                    var gameObject = GameObject.Find("MenuCanvas");
                    _menuCanvas = gameObject.GetComponent<CanvasController>();
                }

                return _menuCanvas;
            }   
        }

        public static TrapController TrapController
        {
            get { return _trapController; } 
            set { _trapController = value; }
        }

        public static PlayerBonusesController PlayerBonusesController
        {
            get { return _playerBonusesController; } 
            set { _playerBonusesController = value; }
        }

        public static TrapData TrapData
        {
            get { return   _trapData; }
            set { _trapData = value; }
        }
        
        public static BuffData BuffData
        {
            get { return   _buffData; }
            set { _buffData = value; }
        }
    }
}