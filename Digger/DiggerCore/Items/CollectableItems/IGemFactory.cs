namespace DiggerCore.Items.CollectableItems {
    public interface IGemFactory {
        ICollectable Get<T>()
            where T : ICollectable;
    }
}