namespace DiggerCore.Commands {
    public class CheckEntryPossibility : ICommand {
        public Direction Direction { get; }
        public Digger Digger { get; }

        public CheckEntryPossibility(Direction direction, Digger digger) {
            Direction = direction;
            Digger = digger;
        }
    }
}
