using Code.SaveData;
using UnityEngine;

namespace Code.Canvas
{
    public class SaveLoadManager : MonoBehaviour
    {
        private SaveDataRepository _saveDataRepository;

        public void SaveGame()
        {
            if (_saveDataRepository == null) _saveDataRepository = new SaveDataRepository();
            _saveDataRepository.Save();
        }

        public void LoadGame()
        {
            if (_saveDataRepository == null) _saveDataRepository = new SaveDataRepository();
            _saveDataRepository.Load();
        }
    }
}