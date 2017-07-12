namespace DiggerCore {
    public enum TileType {
        Blacked, // for the out-of-map tile rendering
        Dirt, // base tile 
        Surface, // 
        Empty, // free to move undeground tile
        Block, // no move beyond that block 
    }
}