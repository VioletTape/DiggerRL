using System.Collections.Generic;
using System.Linq;

namespace MovementManagerRL {
    public class ActorQueueManager {
        private readonly int grantEnergy;
        private readonly ActorPriorityQueue actorPriorityQueue;
        private readonly List<ActorEnergy> actors;

        public int Turn { get; private set; }

        public ActorQueueManager(int grantEnergy) {
            this.grantEnergy = grantEnergy;

            actorPriorityQueue = new ActorPriorityQueue();
            actors = new List<ActorEnergy>();
        }

        public void Register<T>(T actor) where T : IActor {
            var actorSpeed = new ActorEnergy {
                                                 Actor = actor
                                                 , AccumulatedEnergy = 0
                                             };
            actors.Add(actorSpeed);
            actorPriorityQueue.Add(actorSpeed);
        }

        public void Remove<T>(T actor) { }

        public void RemoveAll<T>() { }

        public IActor PopNext() {
            var action = actorPriorityQueue.GetNext();
            if (action == null) {
                if (Rebuild()) {
                    return PopNext();
                }
                return null;
            }

            action.AccumulatedEnergy -= action.Actor.Speed;

            return action.Actor;
        }

        internal bool Rebuild() {
            actors.ForEach(a => { a.AccumulatedEnergy += grantEnergy; });
            actorPriorityQueue.AddRange(actors);
            Turn++;
            return actors.Any();
        }

        public void Add<T>(T actor) where T : IActor {
            var actorSpeed = new ActorEnergy {
                                                 Actor = actor
                                                 , AccumulatedEnergy = actor.Speed
                                             };
            actorPriorityQueue.Add(actorSpeed);
        }
    }
}
