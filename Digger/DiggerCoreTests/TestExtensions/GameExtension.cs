using DiggerCore;
using DiggerCore.Commands;

namespace DiggerCoreTests.TestExtensions {
    public static class GameExtension {
        public static void SendDiggerDown(this Game game) {
            game.Player.Send(DirectionCommand.Down);
        }

        public static void SendDiggerLeft(this Game game) {
            game.Player.Send(DirectionCommand.Left);
        }

        public static void SendDiggerRight(this Game game) {
            game.Player.Send(DirectionCommand.Right);
        }

        public static void SendDiggerUp(this Game game) {
            game.Player.Send(DirectionCommand.Up);
        }
    }
}