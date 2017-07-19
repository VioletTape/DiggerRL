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

        public Game() {
            SetupLog();
            log.Information("New game started");

            CreatePlayer();
        }

        public Game(Rule rule) : this() {
            Map = new Map(rule);
        }

        public void SetMap(Map map) {
            Map = map;
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
        /// <param name="move">Command with proposed direction</param>
        private void PlayerOnMoveCommand(object sender, MoveDirectionCommand move) {
            if (!Map.AllowMovementFrom(move)) {
                return;
            }

            Map.Move(new DiggerMoves(Digger, move.Direction));
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
