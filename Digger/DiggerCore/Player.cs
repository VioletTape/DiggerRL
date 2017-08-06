using System;
using DiggerCore.Commands;
using DiggerCore.Items;
using Serilog;

namespace DiggerCore {
    public class Player {
        private readonly CommandHubService hub;
        private readonly ILogger log = Log.ForContext<Player>();

        internal event EventHandler<MoveDirectionCommand> MoveCommand = (sender, command) => { };

        public Player(CommandHubService hub) {
            this.hub = hub;
            log.Information("{actor} created", "Player");
        }

        public void Send(MoveDirectionCommand directionCommand) {
            log.Verbose("{actor} direct to {moveDirectionCommand}", "Player", directionCommand.Direction);
            MoveCommand(this, directionCommand);
        }

        public void OpenStore() {
            hub.Send(new PlayerOpenStore());
        }

        public void BuyItem(IItem item) {
            hub.Send(new PlayerBuyItem(item));
        }
    }
}
