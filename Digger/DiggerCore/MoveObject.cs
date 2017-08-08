using DiggerCore.Tiles;
using Serilog;

namespace DiggerCore {
    public abstract class MoveObject {
        protected readonly ILogger log = Log.ForContext<Digger>();

        public MoveObject(string actor) {
            log.Information("{actor} created", actor);
        }

        public abstract bool Move(Tile tile);
    }
}