using System.Collections.Generic;
using System.Linq;
using DiggerCore.Commands;
using DiggerCore.Items;
using Serilog;

namespace DiggerCore.Services {
    public class StoreService : IService {
        private ILogger log = Log.ForContext<StoreService>();
        private List<IItem> goods;

        internal Digger digger;

        public StoreService() {
            goods = new List<IItem> {
                                        new Bridge()
                                        , new Stick()
                                        , new Ladder()
                                    };
        }

        public void Handle(PlayerOpenStore command) {
            if (digger == null) { }
        }

        public void Handle(PlayerBuyItem command) {
            if (digger?.Gold - command.Item.Price >= 0) {
                digger.Gold -= command.Item.Price;
                var type = command.Item.GetType();
                if (!digger.Items.ContainsKey(type)) {
                    digger.Items.Add(type, 0);
                }
                digger.Items[type]++;
            }
        }

        public void Handle(DiggerInStore command) {
            digger = command.Digger;
            digger.Gold += digger.GemBag.Gems.Sum(i => i.Value);
            digger.GemBag.Clear();
        }

        public void Handle(DiggerLeftStore command) {
            digger = null;
        }
    }

    public interface IService { }
}
