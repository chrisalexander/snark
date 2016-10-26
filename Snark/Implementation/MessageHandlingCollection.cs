using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Snark.Handlers;

namespace Snark.Implementation
{
    public class MessageHandlingCollection
    {
        private ConcurrentDictionary<Type, HashSet<AbstractHandler>> collections = new ConcurrentDictionary<Type, HashSet<AbstractHandler>>();

        private HashSet<AbstractHandler> allTypes = new HashSet<AbstractHandler>();

        public void Add(AbstractHandler handler)
        {
            var types = handler.SupportedMessageTypes().ToList();

            if (types.Count == 0)
            {
                allTypes.Add(handler);
            }

            foreach (var type in types)
            {
                this.GetSet(type).Add(handler);
            }
        }
        
        public void Remove(AbstractHandler handler)
        {
            allTypes.Remove(handler);
            this.collections.Values.Select(v => v.Remove(handler));
        }

        public IEnumerable<AbstractHandler> Subscribers(Type key)
        {
            return this.allTypes.Concat(this.GetSet(key));
        }

        private HashSet<AbstractHandler> GetSet(Type key)
        {
            return this.collections.GetOrAdd(key, _ => new HashSet<AbstractHandler>());
        }
    }
}
