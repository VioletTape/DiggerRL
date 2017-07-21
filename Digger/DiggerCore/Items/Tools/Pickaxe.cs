namespace DiggerCore.Items.Tools {
    public class Pickaxe : ITool {
        public string Name { get; private set; }

        public int Price { get; private set; }

        public int Power { get; private set; }

        /// <summary>
        ///     Influence on Stamina.
        /// </summary>
        public int Weight { get; private set; }

        public Pickaxe() {
            Name = "Rusty pickaxe";
            Price = 0;
            Power = 5;
            Weight = 3;
        }

        public void Upgrade(PickaxeSettings settings) {
            Name = settings.Name;
            Price = settings.Price;
            Power = settings.Power;
            Weight = settings.Weight;
        }
       
    } public class PickaxeSettings : IItem {
            public string Name { get; }
            public int Price { get; }
            public int Power { get; }
            public int Weight { get; }
        }
}
