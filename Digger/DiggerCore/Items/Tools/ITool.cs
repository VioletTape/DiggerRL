namespace DiggerCore.Items.Tools {
    // non consumable
    public interface ITool : IItem {
        int Power { get; }
        int Weight { get; }
    }
}
