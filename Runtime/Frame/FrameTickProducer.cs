using UnityEngine;

namespace Spark
{
    internal class FrameTickProducer : TickerProducerBase
    {
        private void Update()
        {
            OnTick();
        }

        public static FrameTickProducer Create()
        {
            var go = new GameObject(nameof(FrameTickProducer));
            return go.AddComponent<FrameTickProducer>();
        }
    }
}