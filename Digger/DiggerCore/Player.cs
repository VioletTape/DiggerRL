using System;
using System.Diagnostics;
using DiggerCore.Commands;
using Serilog;
using Serilog.Core;

namespace DiggerCore {
    public class Player {
        private readonly ILogger log = Log.ForContext<Player>();

        internal event EventHandler<MoveDirectionCommand> MoveCommand = (sender, command) => { };

        public Player() {
            log.Information("{actor} created", "Player");
        }

        public void Send(MoveDirectionCommand directionCommand) {
            log.Verbose("{actor} direct to {moveDirectionCommand}", "Player", directionCommand.Direction);
            MoveCommand(this, directionCommand);
        }
    }
}
