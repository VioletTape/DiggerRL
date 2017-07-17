using System;
using System.Collections.Generic;
using DiggerCore.Commands;
using DiggerCore.Items;
using DiggerCore.Items.Tools;

namespace DiggerCore {
    public class Digger {
        public int Stamina { get; set; }
        public int Gold;

        public ITool Weapon;
        public ITool Flare;

        public readonly Dictionary<Type, int> Items = new Dictionary<Type, int>();
        public readonly Dictionary<Type, int> Bag = new Dictionary<Type, int>();

        public Digger() {
            Stamina = 100;
            Weapon = new Pickaxe();
        }

        public void Move(MoveCommand move) {
            Stamina -= move.ActiveTile.StaminaPrice;
        }

        public int UseWeapon() {
            Stamina -= Weapon.Weight;
            return Weapon.Power;
        }

        public override string ToString() {
            return $"Stamina: {Stamina}";
        }
    }
}
