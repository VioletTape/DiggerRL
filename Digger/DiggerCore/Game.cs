using System.Collections.Generic;
using System.Linq;
using DiggerCore.Commands;
using DiggerCore.Services;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace DiggerCore {
    public class Game {
        private List<IService> services = new List<IService>();
        
        public Map Map;
        public Player Player;
        public Digger Digger;
        private ILogger log;
        public readonly CommandHubService Hub;


        public Game() {
            SetupLog();
            log.Information("New game started");

            Hub = new CommandHubService();
            var campService = new CampService();
            Hub.Subscribe<DiggerInCamp>(campService.Handle);
            Hub.Subscribe<DiggerLeftCamp>(campService.Handle);
            services.Add(campService);

            var storeService = new StoreService();
            Hub.Subscribe<DiggerInStore>(storeService.Handle);
            Hub.Subscribe<DiggerLeftStore>(storeService.Handle);
            Hub.Subscribe<PlayerOpenStore>(storeService.Handle);
            Hub.Subscribe<PlayerBuyItem>(storeService.Handle);
            services.Add(storeService);

            CreatePlayer();
        }

        public Game(Rule rule) : this() {
            Map = new Map(rule);
        }

        public T Get<T>()
            where T : IService {
            return services.OfType<T>().SingleOrDefault();
        }

        public void SetMap(Map map) {
            Map = map;
        }

        private void CreatePlayer() {
            Player = new Player(Hub);
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
