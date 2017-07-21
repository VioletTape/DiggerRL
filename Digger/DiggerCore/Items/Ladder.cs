namespace DiggerCore.Items {
    public class Ladder : IItem {
        public string Name => "Ladder";
        public int Price => 10;
    }

    public class Stick : IItem {
        public string Name => "Stick";
        public int Price => 5;
    }

    public class Bridge : IItem {
        public string Name => "Bridge";
        public int Price => 50;
    }
}