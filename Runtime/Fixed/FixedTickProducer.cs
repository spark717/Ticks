using UnityEngine;

namespace Spark
{
    internal class FixedTickProducer : TickerProducerBase
    {
        private void FixedUpdate()
        {
            OnTick();
        }
        
        public static FixedTickProducer Create()
        {
            var go = new GameObject(nameof(FixedTickProducer));
            return go.AddComponent<FixedTickProducer>();
        }
    }
}