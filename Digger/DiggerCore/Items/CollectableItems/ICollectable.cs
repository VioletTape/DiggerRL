namespace DiggerCore.Items.CollectableItems {
    public interface ICollectable {
        int Value { get; }
    }

    public class Coal : ICollectable {
        public int Value => 10;
    }
}