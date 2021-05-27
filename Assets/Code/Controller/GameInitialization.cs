using Code.Canvas;
using Code.MiniMap;
using UnityEngine;

namespace Code
{
    internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, Data data)
        {
            var camera = Camera.main;

            #region Input
            var inputInitialization = new InputInitialization();
            controllers.Add(inputInitialization);
            controllers.Add(new InputController(inputInitialization.GetInput()));
            #endregion
            
            #region Player
            var playerFactory = new PlayerFactory(data.Player);
            var playerInitialization = new PlayerInitialization(playerFactory);
            var playerBonusesController = new PlayerBonusesController(playerInitialization.GetPlayer(), data.Trap);
            controllers.Add(playerInitialization);
            controllers.Add(playerBonusesController);
            controllers.Add(new PlayerShootController(playerInitialization.GetPlayer()));
            controllers.Add(new MoveController(inputInitialization.GetInput(), playerInitialization.GetPlayer(),
                data.Player));
            #endregion

            #region Trap
            var trapFactory = new TrapFactory(data.Trap);
            var trapController = new TrapController(trapFactory,
                playerInitialization.GetPlayer().gameObject.GetInstanceID(),
                playerBonusesController);
            controllers.Add(trapController);
            #endregion

            controllers.Add(new CameraInGameController(playerInitialization.GetPlayer(), camera.transform));
            controllers.Add(new MiniMapScr(playerInitialization.GetPlayer().transform));
            controllers.Add(new EndGameController());

            Reference.BuffData = new BuffData();
            Reference.TrapController = trapController;
            Reference.PlayerBonusesController = playerBonusesController;
            Reference.TrapData = data.Trap;
        }
    }
}