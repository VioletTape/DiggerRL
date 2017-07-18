using System;
using System.Collections.Generic;
using DiggerCore.Commands;
using DiggerCore.Items;
using DiggerCore.Items.Tools;
using Serilog;

namespace DiggerCore {
    public class Digger {
        private readonly ILogger log = Log.ForContext<Digger>();
        private static string actor = "Digger";

        public int MaxStamina;
        public int Stamina;
        public int Gold;

        public ITool Weapon;
        public ITool Flare;

        public readonly Dictionary<Type, int> Items = new Dictionary<Type, int>();
        public readonly Dictionary<Type, int> Bag = new Dictionary<Type, int>();

        public Digger() {
            Stamina = MaxStamina = 100;
            Weapon = new Pickaxe();
            log.Verbose("{actor} created {@weapon}, stamina left {stamina}", actor, Weapon, Stamina);
            log.Information("{actor} {digger} created", "Digger", this);
        }

        public void Move(MoveCommand move) {
            Stamina -= move.ActiveTile.StaminaPrice;
            log.Verbose("Stamina reduced on {staminaPrice}", move.ActiveTile.StaminaPrice);
            log.Verbose("{actor} moves {diggerMoveDirection}, stamina left {stamina}",actor, move.Direction, Stamina);
        }

        public int UseWeapon() {
            Stamina -= Weapon.Weight;
            log.Verbose("{actor} use {@weapon}, stamina left {stamina}",actor, Weapon, Stamina);
            return Weapon.Power;
        }

        public override string ToString() {
            return $"Stamina: {Stamina}, Gold: {Gold}";
        }
    }
}
