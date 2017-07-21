namespace DiggerCore.Commands {
    public class SaveGameCommand : ICommand {}
    public class DiggerInCamp : ICommand {}
    public class DiggerLeftCamp : ICommand {}

    public class DiggerInStore : ICommand {
        public readonly Digger Digger;

        public DiggerInStore(Digger digger) {
            Digger = digger;
        }
    }
    public class DiggerLeftStore : ICommand {}
}
