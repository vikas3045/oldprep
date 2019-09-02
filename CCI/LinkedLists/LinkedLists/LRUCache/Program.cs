using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LRUCache
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class LRUCache<K, V>
    {
        private readonly int _capacity;
        private Dictionary<K, LinkedListNode<LRUCacheItem<K, V>>> _cacheMap = new Dictionary<K, LinkedListNode<LRUCacheItem<K, V>>>();
        private LinkedList<LRUCacheItem<K, V>> _lruList = new LinkedList<LRUCacheItem<K, V>>();

        public LRUCache(int capacity)
        {
            _capacity = capacity;
        }

        // Below attribute is for lock
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Add(K key, V val)
        {
            if (_cacheMap.Count >= _capacity)
            {
                RemoveFirst();
            }

            LRUCacheItem<K, V> cacheItem = new LRUCacheItem<K, V>(key, val);
            LinkedListNode<LRUCacheItem<K, V>> node = new LinkedListNode<LRUCacheItem<K, V>>(cacheItem);
            _lruList.AddLast(node);
            _cacheMap.Add(key, node);
        }
        
        [MethodImpl(MethodImplOptions.Synchronized)]
        public V Get(K key)
        {
            LinkedListNode<LRUCacheItem<K, V>> node;

            if (_cacheMap.TryGetValue(key, out node))
            {
                V value = node.Value.value;
                _lruList.Remove(node);
                _lruList.AddLast(node);

                return value;
            }

            return default(V);
        }       

        private void RemoveFirst()
        {
            // Remove from LRUPriority
            LinkedListNode<LRUCacheItem<K, V>> node = _lruList.First;
            _lruList.RemoveFirst();

            // Remove from cache
            _cacheMap.Remove(node.Value.key);
        }
    }

    class LRUCacheItem<K, V>
    {
        public LRUCacheItem(K k, V v)
        {
            key = k;
            value = v;
        }
        public K key;
        public V value;
    }
}
