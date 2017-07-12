namespace DiggerCore.Tiles {
    public class EmptyTile : Tile
    {
        public EmptyTile() : base(TileType.Empty) { }

        public override int StaminaPrice => 2;
    }
}