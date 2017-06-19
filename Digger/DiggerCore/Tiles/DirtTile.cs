namespace DiggerCore.Tiles {
    public class DirtTile : Tile {
        public DirtTile() : base(TileType.Dirt) { }

        public override int StaminaPrice => 1;
    }
}