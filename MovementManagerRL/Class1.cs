using System;
using System.Collections.Generic;

namespace MovementManagerRL {
    public class ActorPriorityQueue {
        private List<ActorSpeed> queue = new List<ActorSpeed>();

        public IEnumerable<ActorSpeed> Items => queue;

        public void Add(IActor actor) {
            var actorSpeed = new ActorSpeed { Actor = actor, AccumulatedEnergy = 0};
            queue.Add(actorSpeed);
        }

        public void Add(IActor actor, int accumulatedEnergy) {
            var actorSpeed = new ActorSpeed { Actor = actor, AccumulatedEnergy = accumulatedEnergy};
            queue.Add(actorSpeed);
        }

        public void AddRange(List<ActorSpeed> list) {
            queue.Clear();
            queue.AddRange(list);
        }

        public ActorSpeed GetNext() {
            var actor = queue.Find(a => a.AccumulatedEnergy >= a.Actor.Speed);
            queue.Remove(actor);
            return actor;
        }
    }

    public class ActorSpeed {
        public IActor Actor;
        public int AccumulatedEnergy;
    }

    public class ActorQueueManager {
        private readonly int grantEnergy;
        private ActorPriorityQueue actorPriorityQueue;
        private List<ActorSpeed> actors;

        public ActorQueueManager(int grantEnergy) {
            this.grantEnergy = grantEnergy;
            actorPriorityQueue = new ActorPriorityQueue();
            actors = new List<ActorSpeed>();
        }

        public void Register<T>(T beast) where T : IActor { 
            actorPriorityQueue.Add(beast);
        }

        public IActor PopNext() {
            var actor = actorPriorityQueue.GetNext();
            if (actor == null) {
                Rebuild();
                return PopNext();
            }

            actor.AccumulatedEnergy -= actor.Actor.Speed;
            actors.Add(actor);

            return actor.Actor;
        }

        public void Rebuild() {
            Console.WriteLine("Rebuild");
            actors.AddRange(actorPriorityQueue.Items);
            actors.ForEach(a => {
                               a.AccumulatedEnergy += grantEnergy;
                           });
            actorPriorityQueue.AddRange(actors);
            actors.Clear();
        }
    }



    public interface IActor {
        int Speed { get; set; }
    }

    public class NullActor : IActor {
        private static NullActor actor;

        public static NullActor Instance {
            get {
                actor = actor ?? new NullActor();
                return actor;
            }
        }

        private NullActor() { }

        public int Speed {
            get => int.MaxValue;
            set { }
        }

       
    }
}
