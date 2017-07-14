using DiggerCore;
using DiggerCore.Commands;
using DiggerCore.Tiles;

namespace DiggerCoreTests.TileArrayTests {
    public class TestTile : Tile {
        public TestTile(TileType type, int staminaPrice = 1) : base(type) {
            StaminaPrice = staminaPrice;
        }
        public override int StaminaPrice { get; }
        public override bool AllowMovementTo(Direction direction) {
            return true;
        }

        public override bool AllowEntrance() {
            return true;
        }
    }
}
