using System.IO;
using UnityEngine;

namespace Code
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    public sealed class Data : ScriptableObject
    {
        [SerializeField] private string _PlayerDataPath;
        [SerializeField] private string _TrapsDataPath;
        [SerializeField] private string _MainMenuDataPath;

        private PlayerData _player;
        private TrapData _trap;
        private MainMenuData _mainMenuData;

        public PlayerData Player
        {
            get
            {
                if (_player == null)
                {
                    _player = Load<PlayerData>("Data/" + _PlayerDataPath);
                }

                return _player;
            }
        }

        public TrapData Trap
        {
            get
            {
                if (_trap == null)
                {
                    _trap = Load<TrapData>("Data/" + _TrapsDataPath);
                }

                return _trap;
            }
        }

        public MainMenuData MainMenuData
        {
            get
            {
                if (_mainMenuData == null)
                {
                    _mainMenuData = Load<MainMenuData>("Data/" + _MainMenuDataPath);
                }
                
                return _mainMenuData;
            }
        }


        private T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    }
}