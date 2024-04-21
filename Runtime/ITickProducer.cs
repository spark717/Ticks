using System;

namespace Spark
{
    public interface ITickProducer
    {
        public event Action TickSignal;
    }
}