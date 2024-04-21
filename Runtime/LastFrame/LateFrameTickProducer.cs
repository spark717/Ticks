using UnityEngine;

namespace Spark
{
    internal class LateFrameTickProducer : TickerProducerBase
    {
        private void LateUpdate()
        {
            OnTick();
        }
        
        public static LateFrameTickProducer Create()
        {
            var go = new GameObject(nameof(LateFrameTickProducer));
            return go.AddComponent<LateFrameTickProducer>();
        }
    }
}