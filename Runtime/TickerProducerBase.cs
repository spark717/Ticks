using System;
using UnityEngine;

namespace Spark
{
    public abstract class TickerProducerBase : MonoBehaviour, ITickProducer
    {
        public event Action TickSignal;

        protected void OnTick()
        {
            TickSignal?.Invoke();
        }
    }
}