namespace DiggerCore.Items.Tools {
    public class Pickaxe : ITool {
        public string Name { get; }
        public int Value { get;  }
        public int Power { get;  }
        /// <summary>
        /// Influence on Stamina. 
        /// </summary>
        public int Weight { get;  }

        public Pickaxe() {
            Name = "Rusty pickaxe";
            Value = 0;
            Power = 5;
            Weight = 3;
        }
    }

}