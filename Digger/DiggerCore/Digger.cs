using System;
using System.Collections.Generic;
using DiggerCore.Items.Tools;
using DiggerCore.Tiles;
using Serilog;

namespace DiggerCore {
    public class Digger : MoveObject {
        private readonly ILogger log = Log.ForContext<Digger>();
        private static readonly string actor = "Digger";

        public int MaxStamina;
        public int Stamina;
        public int Gold;

        public ITool Tool;
        public IFlare Flare;
        public IGemBag GemBag = new GemBag();

        public readonly Dictionary<Type, int> Items = new Dictionary<Type, int>();

        public Digger() : base(actor) {
            Stamina = MaxStamina = 100;
            Tool = new Pickaxe();

            log.Verbose("{actor} created with {@weapon}, initial stamina {stamina}", actor, Tool, Stamina);
        }

        public override bool Move(Tile tile) {
            Stamina -= tile.StaminaPrice;

            log.Verbose("Stamina reduced on {staminaPrice}", tile.StaminaPrice);
            log.Verbose("{actor} moved, stamina left {stamina}", actor, Stamina);

            return true;
        }

        public int Attack() {
            Stamina -= Tool.Weight;

            log.Verbose("{actor} use {@weapon}, stamina left {stamina}", actor, Tool, Stamina);
            return Tool.Power;
        }

        public override string ToString() {
            return $"Stamina: {Stamina}, Gold: {Gold}";
        }
    }
}
