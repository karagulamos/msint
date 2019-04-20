using System;
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
            var entryExists = _cacheEntries.TryGetValue(key, out var entry);

            if(!entryExists && _cacheEntries.Count >= _capacity)
                RemoveLeastRecentlyUsedEntry();
            
            if(entryExists) _journal.Remove(entry);            

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
            var builder = new StringBuilder(_journal.Count * 3);

            builder.Append('[');

            for(var curr = _journal.First; curr != null; curr = curr.Next)
            {
                builder.Append(curr.Value);

                if(curr.Next != null)
                    builder.Append(", ");
            }

            return builder.Append(']').ToString();
        }
    }
}