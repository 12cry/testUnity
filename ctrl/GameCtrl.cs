using Cry.Common;
using testUnity.model;

namespace testUnity.ctrl {
    public class GameCtrl : Singleton<GameCtrl> {
        Game game = new Game();
        void Start () {
            game.initTeam ();

            // ResourceUI.instance.init ();
            // CameraRig.instance.init (column, row);

        }

    }
}