using System.IO;
using UnityEngine;

namespace Code.SaveData
{
    public sealed class SaveDataRepository
    {
        private readonly IData<SavedData> _data;

        private const string _folderName = "dataSave";
        private const string _fileName = "data.bat";
        private readonly string _path;

        public SaveDataRepository()
        {
            _data = new XMLData();

            _path = Path.Combine(Application.dataPath, _folderName);
        }

        public void Save()
        {
            var player = Reference.PlayerBall;
            var trapController = Reference.TrapController;
            var bonusesController = Reference.PlayerBonusesController;

            var saveData = new SavedData()
            {
                Name = "Dima",
                Position = player.transform.position,
                currentActiveTrapsList = new CurrentActiveTrapsList(trapController.CurrentActiveTraps),
                playerBuffs = bonusesController.TrapBuffList
            };
            Debug.Log(saveData);

            _data.Save(saveData, Path.Combine(_path, _fileName));
        }

        public void Load()
        {
            var player = Reference.PlayerBall;
            var trapController = Reference.TrapController;
            var bonusesController = Reference.PlayerBonusesController;

            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file)) return;
            var newPlayer = _data.Load(file);
            trapController.RemoveAllTraps();
            
        }
    }
}