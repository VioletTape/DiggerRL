using System.Collections.Generic;

namespace MovementManagerRL {
    internal class ActorPriorityQueue {
        private readonly List<ActorEnergy> queue = new List<ActorEnergy>();

        internal void Add(ActorEnergy actor) {
            queue.Add(actor);
        }

        internal void AddRange(List<ActorEnergy> list) {
            queue.Clear();
            queue.AddRange(list);
        }

        internal ActorEnergy GetNext() {
            var actor = queue.Find(a => a.AccumulatedEnergy >= a.Actor.Speed);
            if (actor != null) {
                queue.Remove(actor);
                if (actor.AccumulatedEnergy >= actor.Actor.Speed) {
                    queue.Add(actor);
                }
            }
            return actor;
        }
    }
}