namespace DiggerCore.Tiles {
    public class DirtTile : Tile {
        public DirtTile() : base(TileType.Dirt) { }

        public override int StaminaPrice => 4;
    }

    public class BlockTile : Tile
    {
        public BlockTile() : base(TileType.Block) { }

        public override int StaminaPrice => 0;

        public override bool IsDestructale => false;
    }
}