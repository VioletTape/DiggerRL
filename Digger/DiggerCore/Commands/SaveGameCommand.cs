using DiggerCore.Items;

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
    public class PlayerOpenStore : ICommand {}

    public class PlayerBuyItem : ICommand {
        public readonly IItem Item;

        public PlayerBuyItem(IItem item) {
            Item = item;
        }
    }
}
