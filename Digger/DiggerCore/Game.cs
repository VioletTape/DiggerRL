using DiggerCore.Commands;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace DiggerCore {
    public class Game {
        public Map Map;
        public Player Player;
        public Digger Digger;
        private ILogger log;

        public Game(Rule rule) {
            SetupLog();
            log.Information("New game started");
            Map = new Map(rule);

            CreatePlayer();
        }

        public Game(Map map) {
            SetupLog();
            log.Information("New game with provided map started");

            Map = map;

            CreatePlayer();
        }

        private void CreatePlayer() {
            Player = new Player();
            Digger = new Digger();

            Player.MoveCommand += PlayerOnMoveCommand;
        }

        /// <summary>
        ///     Get next active tile and pass it to Digger, to detect what can be done with that tile
        /// </summary>
        /// <param name="sender">Player object</param>
        /// <param name="moveDirectionCommand">Command with proposed direction</param>
        private void PlayerOnMoveCommand(object sender, MoveDirectionCommand moveDirectionCommand) {
            if (!Map.GetCurrentTile().AllowMovementTo(moveDirectionCommand.Direction)) {
                log.Verbose("{actor} {movement} on {tileCoordinate}", "Digger", "stay", Map.DiggerPosition);
                return;
            }

            var activeTile = Map.GetTileNextTo(moveDirectionCommand);
            log.Verbose("Next active tile is {tile}", activeTile);

            if (activeTile.AllowEntrance(Digger)) {
                var moveCommand = new MoveCommand(moveDirectionCommand.Direction, activeTile);
                Digger.Move(moveCommand);
                Map.MoveDigger(moveCommand);
                log.Information("{actor} {movement} on {tileCoordinate}. Stamina left {stamina}, gold {gold}", 
                    "Digger", "move", Map.DiggerPosition, Digger.Stamina, Digger.Gold);
            }
        }

        private void SetupLog() {
            var levelSwitch = new LoggingLevelSwitch {
                                                         MinimumLevel = LogEventLevel.Verbose
                                                     };

            Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.ControlledBy(levelSwitch)
                    .WriteTo.Async(x => x.Seq("http://localhost:5341"))
                    .CreateLogger();

            log = Log.Logger;
        }

        public void EndGame() {
            Log.CloseAndFlush();
        }
    }
}
