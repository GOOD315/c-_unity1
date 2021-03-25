using UnityEngine;

namespace Code
{
    [CreateAssetMenu(fileName = "MainMenuInterface", menuName = "Data/Interface/MainMenuInterface", order = 0)]
    public sealed class MainMenuData : ScriptableObject
    {
        [SerializeField] public GameObject _mainMenuCanvas;
    }
}