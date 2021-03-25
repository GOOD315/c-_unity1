using Code.Canvas;
using UnityEngine;

namespace Code
{
    internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, Data data)
        {
            var camera = Camera.main;
            var inputInitialization = new InputInitialization();
            var playerFactory = new PlayerFactory(data.Player);
            var playerInitialization = new PlayerInitialization(playerFactory);
            var playerBonusesController = new PlayerBonusesController(playerInitialization.GetPlayer());
            var trapFactory = new TrapFactory(data.Trap);
            var trapController = new TrapController(trapFactory,
                playerInitialization.GetPlayer().gameObject.GetInstanceID(),
                playerBonusesController, new TrapList(data.Trap));
            controllers.Add(inputInitialization);
            controllers.Add(playerInitialization);
            controllers.Add(trapController);
            controllers.Add(playerBonusesController);
            controllers.Add(new InputController(inputInitialization.GetInput()));
            controllers.Add(new MoveController(inputInitialization.GetInput(), playerInitialization.GetPlayer(),
                data.Player));
            controllers.Add(new CameraInGameController(playerInitialization.GetPlayer(), camera.transform));
            controllers.Add(new EndGameController());


            Reference.TrapController = trapController;
            Reference.PlayerBonusesController = playerBonusesController;
        }
    }
}