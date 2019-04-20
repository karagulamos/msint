using System.Collections.Generic;
using System.Text;

namespace Euler.Cache
{
    public class FastBoundedCache<TKey, TValue>
    {
        private readonly Dictionary<TKey, LinkedListNode<TValue>> _cacheEntries;
        private readonly LinkedList<TValue> _journal;

        private readonly int _capacity;

        public FastBoundedCache(int capacity)
        {
            _capacity = capacity;
            _cacheEntries = new Dictionary<TKey, LinkedListNode<TValue>>();
            _journal = new LinkedList<TValue>();
        }

        public void Insert(TKey key, TValue value)
        {
            var hasKey = _cacheEntries.TryGetValue(key, out var entry);

            if(!hasKey && _cacheEntries.Count >= _capacity)
                RemoveLeastRecentlyUsedEntry();
            
            if(hasKey) _journal.Remove(entry);            

            var newEntry = new LinkedListNode<TValue>(value);
            _journal.AddLast(newEntry);
                       
            _cacheEntries[key] = newEntry;        
        }

        public TValue Retrieve(TKey key)
        {
            if(!_cacheEntries.TryGetValue(key, out var entry))
                throw new KeyNotFoundException();            

            _journal.Remove(entry);
            _journal.AddFirst(entry);

            return entry.Value;            
        }

        private void RemoveLeastRecentlyUsedEntry()
        {
            if(_journal.Count == 0)
                return;
                
            _journal.RemoveLast();
        }

        public override string ToString() 
        {
            var builder = new StringBuilder();

            builder.Append('[');

            var current = _journal.First;

            while(current != null)
            {
                builder.Append(current.Value);

                if(current.Next != null)
                    builder.Append(", ");

                current = current.Next;
            }

            return builder.Append(']').ToString();
        }
    }
}