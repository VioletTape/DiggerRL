using System;
using System.Collections.Generic;

namespace DiggerCore.Commands {
    public class CommandHubService {
        private readonly Dictionary<Type, Action<ICommand>> comms;

        public CommandHubService() {
            comms = new Dictionary<Type, Action<ICommand>>();
        }

        public void Handle<T>(T command) where  T : ICommand{
            comms[typeof(T)].Invoke(command);
        }

        public void Subscribe<T>(Action<T> action) where T : ICommand {
            comms.Add(typeof(T), c => action((T)c));
        }
    }
}
