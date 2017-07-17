namespace DiggerCore.Items.Tools {
    // non consumable
    public interface ITool {
        string Name { get; }
        int Value { get; }
        int Power { get; }
        int Weight { get; }
    }

    // consumable 
}
