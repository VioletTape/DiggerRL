using System.Collections.Generic;

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

        public void Register<T>(T actor)
            where T : IActor {
            var actorSpeed = new ActorEnergy {
                                                Actor = actor
                                                , AccumulatedEnergy = 0
                                            };
            actors.Add(actorSpeed);
            actorPriorityQueue.Add(actorSpeed);
        }

        public void Remove<T>(T actor) {
            
        }

        public void RemoveAll<T>() {
            
        }

        public IActor PopNext() {
            var action = actorPriorityQueue.GetNext();
            if (action == null) {
                Rebuild();
                return PopNext();
            }

            action.AccumulatedEnergy -= action.Actor.Speed;

            return action.Actor;
        }

        internal void Rebuild() {
            actors.ForEach(a => { a.AccumulatedEnergy += grantEnergy; });
            actorPriorityQueue.AddRange(actors);
            Turn++;
        }
    }
}