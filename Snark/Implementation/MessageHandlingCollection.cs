using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Snark.Handlers;

namespace Snark.Implementation
{
    public class MessageHandlingCollection<T>
        where T : AbstractHandler
    {
        private ConcurrentDictionary<Type, HashSet<T>> collections = new ConcurrentDictionary<Type, HashSet<T>>();

        private HashSet<T> allTypes = new HashSet<T>();

        public void Add(T handler)
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
        
        public void Remove(T handler)
        {
            allTypes.Remove(handler);
            this.collections.Values.Select(v => v.Remove(handler));
        }

        public IEnumerable<T> Subscribers(Type key)
        {
            return this.allTypes.Concat(this.GetSet(key));
        }

        private HashSet<T> GetSet(Type key)
        {
            return this.collections.GetOrAdd(key, _ => new HashSet<T>());
        }
    }
}
