using DiggerCore;
using DiggerCore.Commands;
using DiggerCore.Tiles;

namespace DiggerCoreTests.TileArrayTests {
    public class TestTile : Tile {
        public TestTile(TileType type, int staminaPrice = 1) : base(type) {
            StaminaPrice = staminaPrice;
        }
        public override int StaminaPrice { get; }
        public override int Density { get; protected set; } = 0;

        public override bool AllowMovementFrom(Direction direction) {
            return true;
        }

        public override bool AllowEntrance(Digger digger) {
            return true;
        }
    }
}
