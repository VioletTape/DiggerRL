namespace DiggerCore.Tiles {
    public class SurfaceTile : Tile
    {
        public SurfaceTile() : base(TileType.Surface) { }

        public override int StaminaPrice => 1;
    }
}