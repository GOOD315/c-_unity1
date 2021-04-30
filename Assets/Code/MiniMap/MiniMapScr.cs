using UnityEngine;

namespace Code.MiniMap
{
    public sealed class MiniMapScr : IInitialization, IExecute
    {
        private Transform _playerPos;
        private GameObject _camera;
        private GameObject _mainCanvas;
        private GameObject _minimapCanvas;
        private GameObject _minimapView;

        public MiniMapScr(Transform playerPos)
        {
            _playerPos = playerPos;
            _mainCanvas = GameObject.Find("RadarCanvas");
        }

        public void Initialization()
        {
            CreateMiniMapCanvas();
            SetCameraAtView();
        }

        public void Execute(float deltaTime)
        {
            _camera.transform.position = _playerPos.position + new Vector3(0, 20.0f, 0);
        }

        private void CreateMiniMapCanvas()
        {
            /*
              rectTransform.anchorMax = new Vector2(1, 1);
              rectTransform.anchorMin = new Vector2(1, 1);
              rectTransform.anchoredPosition = new Vector2(-100, -100);
              rectTransform.sizeDelta = new Vector2(200, 200);
           */

            _minimapCanvas = Object.Instantiate(Resources.Load<GameObject>("MiniMap/MiniMap"), _mainCanvas.transform);
            _minimapCanvas.name = "MiniMap";
            _minimapView = GameObject.Find("MiniMapView");
        }

        private void SetCameraAtView()
        {
            _camera = new GameObject("MiniMapCamera");
            var ff = _camera.AddComponent<Camera>();
            ff.targetTexture = Resources.Load<RenderTexture>("MiniMap/MiniMapTexture");
            _camera.transform.parent = null;
            _camera.transform.rotation = Quaternion.Euler(90.0f, 0, 0);
            _camera.transform.position = _playerPos.position + new Vector3(0, 20.0f, 0);
        }
    }
}