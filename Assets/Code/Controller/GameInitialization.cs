using UnityEngine;

namespace Code
{
    internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, Data data)
        {
            Camera camera = Camera.main;
            var inputInitialization = new InputInitialization();
            var playerFactory = new PlayerFactory(data.Player);
            var playerInitialization = new PlayerInitialization(playerFactory);
            var trapFactory = new TrapFactory(data.Trap);
            var trapController = new TrapController(trapFactory, playerInitialization.GetPlayer().gameObject.GetInstanceID());
            controllers.Add(inputInitialization);
            controllers.Add(playerInitialization);
            controllers.Add(trapController);
        }
    }
}