using System;
using System.Data;
using DiggerCore.Commands;

namespace DiggerCore {
    public class Player {
        internal event EventHandler<MoveDirectionCommand> MoveCommand = (sender, command) => {};

        public void Send(MoveDirectionCommand directionCommand) {
            MoveCommand(this, directionCommand);
        }
    }

   
}
