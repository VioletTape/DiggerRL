using DiggerCore.ElementalStructures;

namespace DiggerCore {
    public class Rule {
        public Size MapSize = new Size(20, 20);
        public Point DiggerPosition { get; protected set; }
    }
}
