using System;
using System.Collections.Generic;

namespace Spark
{
    public abstract class TickManagerBase<T> : ITickManager<T>
        where T : ITick
    {
        private readonly ITickProducer _tickProducer;
        private readonly Dictionary<Type, int> _order;
        private readonly List<T> _consumersList;
        private readonly List<T> _addPendingList;
        private readonly HashSet<T> _removePendingList;
        
        protected TickManagerBase(Type[] order, ITickProducer tickProducer)
        {
            _consumersList = new();
            _addPendingList = new();
            _removePendingList = new();
            _tickProducer = tickProducer;
            _tickProducer.TickSignal += OnTick;

            _order = new(order.Length);
            for (int i = 0; i < order.Length; i++)
                _order[order[i]] = i;
        }

        public void AddConsumer(T consumer)
        {
            if (consumer == null)
                throw new NullReferenceException();
            
            _addPendingList.Add(consumer);
        }
        
        public void RemoveConsumer(T consumer)
        {
            if (consumer == null)
                throw new NullReferenceException();
            
            _removePendingList.Add(consumer);
        }
        
        private void OnTick()
        {
            ProcessPendingItems();
            
            foreach (var item in _consumersList)
            {
                if (_removePendingList.Contains(item))
                    continue;
                
                ExecuteTick(item);
            }

            ProcessPendingItems();
        }

        private void ProcessPendingItems()
        {
            foreach (var item in _addPendingList)
            {
                _consumersList.Add(item);
            }
            
            foreach (var item in _removePendingList)
            {
                _consumersList.Remove(item);
            }
            
            if (_addPendingList.Count > 0)
                _consumersList.Sort(Compare);
            
            _addPendingList.Clear();
            _removePendingList.Clear();
        }

        private int Compare(T a, T b)
        {
            var i1 = FindOrderIndex(a);
            var i2 = FindOrderIndex(b);;

            return i1.CompareTo(i2);
        }

        private int FindOrderIndex(T item)
        {
            var type = item.GetType();

            if (_order.TryGetValue(type, out var result))
                return result;

            return -1;
        }

        protected abstract void ExecuteTick(T item);
    }
}