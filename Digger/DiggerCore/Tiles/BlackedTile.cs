namespace DiggerCore.Tiles {
    public class BlackedTile : Tile
    {
        public BlackedTile() : base(TileType.Blacked) { }

        public override int StaminaPrice => 1;
    }
}