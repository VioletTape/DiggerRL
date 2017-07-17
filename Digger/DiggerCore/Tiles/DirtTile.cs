using DiggerCore.Commands;

namespace DiggerCore.Tiles {
    public class DirtTile : Tile {
        public DirtTile() : base(TileType.Dirt) {
            Density = 10;
        }

        public override int StaminaPrice => 2;
        public override int Density { get; protected set; }


        public override bool AllowMovementTo(Direction direction) {
            return true;
        }

        public override bool AllowEntrance(Digger digger) {
            if(Density<=0)
                return true;

            Density -= digger.UseWeapon();

            return false;
        }
    }
}