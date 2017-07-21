using System.Collections.ObjectModel;
using DiggerCore.Items.CollectableItems;

namespace DiggerCore.Items.Tools {
    public interface IGemBag {
        ReadOnlyCollection<ICollectable> Gems { get; }
        void Updgrade(BagSettings settings);
        void Add(ICollectable gem);
        void Clear();
    }
}