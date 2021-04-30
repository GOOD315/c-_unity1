using System;
using Code.SaveData;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

namespace Code.Canvas
{
    public class CanvasController : MonoBehaviour
    {
        [SerializeField] private LocationsLoader LocationsLoader;
        private SaveDataRepository _saveDataRepository;
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
                if (_isPaused)
                {
                    UnpauseGame();
                    return;
                }

                PauseGame();
            }
        }

        public void StartGame()
        {
            LocationsLoader.LoadLocation();
            UnpauseGame();
        }

        public void SaveGame()
        {
            if (_saveDataRepository == null) _saveDataRepository = new SaveDataRepository();
            _saveDataRepository.Save();
        }

        public void LoadGame()
        {
            if (_saveDataRepository == null) _saveDataRepository = new SaveDataRepository();
            if (_saveDataRepository.Load(out var saveData))
            {
                LocationsLoader.LoadLocation(saveData);

                UnpauseGame();
            }
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