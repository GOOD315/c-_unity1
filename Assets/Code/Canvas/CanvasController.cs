using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Code.Canvas
{
    public class CanvasController : MonoBehaviour
    {
        [SerializeField] private LocationsLoader LocationsLoader;
        private bool _isPaused = true;

        [SerializeField] private GameObject mainMenuCanvas;
        [SerializeField] private GameObject gameMenuCanvas;

        private void Start()
        {
            mainMenuCanvas.SetActive(true);
            gameMenuCanvas.SetActive(false);

            _isPaused = true;
            LocationsLoader.IsPaused = true;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
            }
        }

        public void StartGame()
        {
            LocationsLoader.LoadLocation();
            mainMenuCanvas.SetActive(false);
            gameMenuCanvas.SetActive(false);

            _isPaused = false;
            LocationsLoader.IsPaused = false;
        }

        public void EndGame()
        {
            Debug.Log("IGRA ZAKON4ILAS'");
        }

        public void ExitGame()
        {
            Application.Quit();

#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
        }

        public void ShowSettings()
        {
            Debug.Log("SETTINGS");
        }

        public void PauseGame()
        {
            if (_isPaused)
            {
                UnpauseGame();
                return;
            }

            Time.timeScale = 0;
            mainMenuCanvas.SetActive(false);
            gameMenuCanvas.SetActive(true);
            _isPaused = true;
            LocationsLoader.IsPaused = true;
        }

        private void UnpauseGame()
        {
            Time.timeScale = 1;
            mainMenuCanvas.SetActive(false);
            gameMenuCanvas.SetActive(false);
            _isPaused = false;
            LocationsLoader.IsPaused = false;
        }
    }
}