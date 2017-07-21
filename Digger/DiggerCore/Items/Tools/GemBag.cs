using System.Collections.Generic;
using System.Collections.ObjectModel;
using DiggerCore.Items.CollectableItems;
using Serilog;

namespace DiggerCore.Items.Tools {
    public class GemBag : IGemBag {
        private ILogger log = Log.ForContext<GemBag>();
        private readonly List<ICollectable> bag = new List<ICollectable>(100);
        private int capacity;

        public string Name { get; private set; }
        public ReadOnlyCollection<ICollectable> Gems => bag.AsReadOnly();

        public GemBag() {
            capacity = 10;
            Name = "Little bag";
        }

        public void Add(ICollectable gem) {
            if (gem.GetType() == typeof(NullGem)) {
                return;
            }

            if (bag.Count < capacity) {
                log.Information("{actor} add {gem} in bag({bagItems})", "Digger", gem.GetType().Name, bag.Count);
                bag.Add(gem);
            }
        }

        public void Clear() {
            bag.Clear();
        }

        public void Updgrade(BagSettings settings) {
            capacity = settings.Capacity;
        }

     
    }
}