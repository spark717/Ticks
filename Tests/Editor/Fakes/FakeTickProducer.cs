using System;
using Spark;

namespace Tests.Editor.Fakes
{
    public class FakeTickProducer : ITickProducer
    {
        public event Action TickSignal;

        public void Invoke()
        {
            TickSignal?.Invoke();
        }
    }
}