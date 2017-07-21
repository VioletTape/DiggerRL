using System;
using System.Collections.Generic;
using DiggerCore.Items.Tools;
using DiggerCore.Tiles;
using Serilog;

namespace DiggerCore {
    public class Digger {
        private readonly ILogger log = Log.ForContext<Digger>();
        private static readonly string actor = "Digger";

        public int MaxStamina;
        public int Stamina;
        public int Gold;

        public ITool Tool;
        public IFlare Flare;
        public IGemBag GemBag = new GemBag();

        public readonly Dictionary<Type, int> Items = new Dictionary<Type, int>();

        public Digger() {
            Stamina = MaxStamina = 100;
            Tool = new Pickaxe();
            log.Verbose("{actor} created {@weapon}, stamina left {stamina}", actor, Tool, Stamina);
            log.Information("{actor} {digger} created", "Digger", this);
        }

        public void Move(Tile tile) {
            Stamina -= tile.StaminaPrice;
            log.Verbose("Stamina reduced on {staminaPrice}", tile.StaminaPrice);
            log.Verbose("{actor} moved, stamina left {stamina}", actor, Stamina);
        }

        public int UseWeapon() {
            Stamina -= Tool.Weight;
            log.Verbose("{actor} use {@weapon}, stamina left {stamina}", actor, Tool, Stamina);
            return Tool.Power;
        }

        public override string ToString() {
            return $"Stamina: {Stamina}, Gold: {Gold}";
        }
    }
}
