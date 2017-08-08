namespace MovementManagerRL.Tests {
    internal class GameElement : IActor {
        public string Name;

        public int Speed { get; set; }

        public GameElement(string s, int speed) {
            Name = s;
            Speed = speed;
        }

        public override string ToString() {
            return "Name " + Name + " Speed " + Speed;
        }
    }
}