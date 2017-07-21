using System;
using System.Collections.Generic;

namespace DiggerCore.Items.CollectableItems {
    public class GemFactory : IGemFactory {
        private Dictionary<Type, ICollectable> gems;

        public static NullGem Null = new NullGem();

        public GemFactory() {
            gems = new Dictionary<Type, ICollectable> {
                                                          {typeof(Coal), new Coal()}
                                                          , {typeof(NullGem), Null}
                                                      };
        }

        public ICollectable Get<T>()
            where T : ICollectable {
            return gems[typeof(T)];
        }
    }
}